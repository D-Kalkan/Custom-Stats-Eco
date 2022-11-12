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

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class ShippingContainerGreenObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(ShippingContainerGreenItem);
        public override LocString DisplayName => Localizer.DoStr("Green Shipping Container");

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(80);
            storage.Storage.AddInvRestriction(new StackLimitRestriction(200));
            storage.Storage.AddInvRestriction(new NotCarriedRestriction());
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
    [LocDisplayName("Green Shipping Container")]
    [Ecopedia("Crafted Objects", "Storage", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class ShippingContainerGreenItem : WorldObjectItem<ShippingContainerGreenObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A large green shipping container for storing items in.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;

    }

    [RequiresSkill(typeof(AdvancedSmeltingSkill), 3)]
    public partial class ShippingContainerGreenRecipe : RecipeFamily
    {
        public ShippingContainerGreenRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ShippingContainer",  //noloc
                Localizer.DoStr("Green Shipping Container"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CorrugatedSteelItem), 32, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ShippingContainerGreenItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 20;
            this.LaborInCalories = CreateLaborInCaloriesValue(340, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ShippingContainerGreenRecipe), 8, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Green Shipping Container"), typeof(ShippingContainerGreenRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RollingMillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
