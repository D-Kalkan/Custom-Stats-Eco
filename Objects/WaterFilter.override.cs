﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using Eco.Core.Utils;
    using Eco.Core.Controller;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Systems.Messaging.Notifications;
    using Eco.Shared.Serialization;
    using Eco.Gameplay.Components;
    using Eco.Shared.Localization;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Shared.Utils;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Simulation.Time;
    using Eco.Gameplay.Players;
    using Eco.Core.Items;
    using PropertyChanged;
    using System.ComponentModel;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Gameplay.Systems.NewTooltip;

    public partial class WasteFilterItem : WorldObjectItem<WasteFilterObject>
    {
        public const float WaterPerCompostBlock = 2000f;
    }

    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(FilterComponent))]
    [RequireComponent(typeof(AttachmentComponent))]
    public partial class WasteFilterObject : WorldObject
    {
    }

    [Serialized] public class FilterItemData : IClearRequestHandler
    {
        [Serialized] public float ProcessedWater { get; set; }

        public Result TryHandleClearRequest(Player player) => Result.FailLoc($"Cannot clear saved state of {typeof(FilterComponent).UILink()}!");
    }

    [Serialized]
    [RequireComponent(typeof(LiquidConverterComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(InOutLinkedInventoriesComponent))] // Waste Filter only has output, so we should add a new component later that only has output
    [RequireComponent(typeof(StatusComponent))]
    [RequireComponent(typeof(MustBeOwnedComponent))]
    [Priority(Priority)]
    [Ecopedia(null, "Pipe Component", display: InPageTooltip.CachedTooltip)]
    public class FilterComponent : WorldObjectComponent, IOperatingWorldObjectComponent, IPersistentData
    {
        // Ensure initialized after PowerGridComponent to setup accumulator
        public const int Priority = PowerGridComponent.Priority + 1;
        [Serialized] public FilterItemData FilterData { get; set; } = new();
        [Serialized] bool shutdownFromFullInv;
        public object PersistentData { get => this.FilterData; set => this.FilterData = value as FilterItemData ?? new(); }

        private LiquidConverterComponent converter;
        StatusElement status;
        
        PeriodicUpdate updateThrottle = new PeriodicUpdate(5, true);

        public override void Initialize()
        {
            this.status   = this.Parent.GetComponent<StatusComponent>().CreateStatusElement();
            this.converter = this.Parent.GetComponent<LiquidConverterComponent>();
            this.converter.Setup(typeof(SewageItem), typeof(WaterItem), this.Parent.GetOccupancyType(BlockOccupancyType.InputPort), this.Parent.GetOccupancyType(BlockOccupancyType.OutputPort), 2f, 0f);
            // buffer will accept liquid even if filter isn't operating and as soon as buffer won't be empty it will become operational
            this.converter.In.BufferSize = 1f;
            this.converter.OnConvert += this.Converted;
            this.Parent.GetComponent<LinkComponent>().OnInventoryContentsChanged.Add(this.TurnOnIfRoom);
        }

        LocString DisplayStatus => Localizer.Do($"{Text.StyledPercent(this.FilterData.ProcessedWater / WasteFilterItem.WaterPerCompostBlock)} of {Item.Get("CompostItem").UILink()} currently filtered.");

        void Converted(float amount)
        {
            this.FilterData.ProcessedWater += amount;
            while (this.FilterData.ProcessedWater > WasteFilterItem.WaterPerCompostBlock)
            {
                var invs = this.Parent.GetComponent<LinkComponent>().GetSortedLinkedInventories(this.Parent.Owners);
                if (!invs.TryAddItem<CompostItem>())
                {
                    this.Parent.GetComponent<OnOffComponent>().On = false;
                    NotificationManager.ServerMessageToAlias(Localizer.Format("{0} disabled, no room left for filtered waste.", this.Parent.UILink()), this.Parent.Owners);
                    this.status.SetStatusMessage(false, Localizer.DoStr("No room for filtered waste."));
                    this.Changed("DisplayStatus");
                    this.Parent.UpdateEnabledAndOperating();
                    this.shutdownFromFullInv = true;
                    return;
                }
                else
                { 
                    this.FilterData.ProcessedWater -= WasteFilterItem.WaterPerCompostBlock;
                    this.status.SetStatusMessage(true, this.DisplayStatus);
                }
            }

            if (this.updateThrottle.DoUpdate)
                this.status.SetStatusMessage(true, this.DisplayStatus);
        }

        void TurnOnIfRoom()
        {
            if (this.shutdownFromFullInv)
            {
                this.Parent.GetComponent<OnOffComponent>().On = true;
                this.shutdownFromFullInv = false;
            }
        }
        public bool Operating => this.converter.In.BufferAmount > 0 || this.converter.In.LastTickConsumed > 0;
    }
}
