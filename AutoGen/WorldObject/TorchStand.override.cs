﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;

    [Serialized]
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class TorchStandObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(TorchStandItem);
        public override LocString DisplayName => Localizer.DoStr("Torch Stand");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        private static string[] fuelTagList = new[] { "Torch" }; //noloc

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(0.5f);
            this.GetComponent<HousingComponent>().HomeValue = TorchStandItem.homeValue;
            this.ModsPostInitialize();
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Torch Stand")]
    [Ecopedia("Housing Objects", "Lights", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [Tag("Housing", 1)]
    [Tag("Small Hewn Furnishing", 1)]
    public partial class TorchStandItem : WorldObjectItem<TorchStandObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A stand for a torch.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.General,
            SkillValue               = 0.8f,
            TypeForRoomLimit         = Localizer.DoStr("Lights"),
            DiminishingReturnPercent = 0.7f
        };

        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(0.5f)}w of {new HeatPower().Name} power from fuel");
    }

    public partial class TorchStandRecipe : RecipeFamily
    {
        public TorchStandRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "TorchStand",  //noloc
                Localizer.DoStr("Torch Stand"),
                new List<IngredientElement>
                {
                    new IngredientElement("HewnLog", 6), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TorchStandItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(10);
            this.CraftMinutes = CreateCraftTimeValue(2);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Torch Stand"), typeof(TorchStandRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
