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

    [RequiresSkill(typeof(CompositesSkill), 5)]
    public partial class ModernUpgradeLvl3Recipe : RecipeFamily
    {
        public ModernUpgradeLvl3Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "ModernUpgradeLvl3",  //noloc
                Localizer.DoStr("Modern Upgrade 3"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(RivetItem), 10, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                    new IngredientElement(typeof(SteelPlateItem), 10, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)),
                    new IngredientElement("CompositeLumber", 16, typeof(CompositesSkill), typeof(CompositesLavishResourcesTalent)), //noloc
                    new IngredientElement(typeof(ModernUpgradeLvl2Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<ModernUpgradeLvl3Item>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(600, typeof(CompositesSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(ModernUpgradeLvl3Recipe), 10, typeof(CompositesSkill), typeof(CompositesFocusedSpeedTalent), typeof(CompositesParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Upgrade 3"), typeof(ModernUpgradeLvl3Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AdvancedCarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Modern Upgrade 3")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Modern Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    [Tag("ModernUpgrade", 1)]
    public partial class ModernUpgradeLvl3Item :
        EfficiencyModule
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Modern Upgrade 3"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Modern Upgrade with great efficiency increase."); } }

        public ModernUpgradeLvl3Item() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.8f         
        ) { }
    }
}