﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;

    [RequiresSkill(typeof(LoggingSkill), 2)]
    public partial class BasicUpgradeLvl1Recipe : RecipeFamily
    {
        public BasicUpgradeLvl1Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "BasicUpgradeLvl1",  //noloc
                Localizer.DoStr("Basic Upgrade 1"),
                new List<IngredientElement>
                {
                    new IngredientElement("HewnLog", 40, typeof(LoggingSkill)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<BasicUpgradeLvl1Item>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BasicUpgradeLvl1Recipe), 2, typeof(LoggingSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Basic Upgrade 1"), typeof(BasicUpgradeLvl1Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Basic Upgrade 1")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Basic Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    [Tag("BasicUpgrade", 1)]
    public partial class BasicUpgradeLvl1Item :
        EfficiencyModule
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Basic Upgrade 1"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Basic Upgrade that increases crafting efficiency."); } }

        public BasicUpgradeLvl1Item() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.95f         
        ) { }
    }
}