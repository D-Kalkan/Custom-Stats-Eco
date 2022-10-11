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

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(MiningSkill), 7)]
    public partial class MiningAdvancedUpgradeRecipe : RecipeFamily
    {
        public MiningAdvancedUpgradeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "MiningAdvancedUpgrade",  //noloc
                Localizer.DoStr("Mining Advanced Upgrade"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(AdvancedUpgradeLvl4Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MiningAdvancedUpgradeItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(6000, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MiningAdvancedUpgradeRecipe), 15, typeof(MiningSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Mining Advanced Upgrade"), typeof(MiningAdvancedUpgradeRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ScreeningMachineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Mining Advanced Upgrade")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Specialty Upgrades", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    public partial class MiningAdvancedUpgradeItem :
        EfficiencyModule
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that greatly increases efficiency when crafting Mining recipes."); } }

        public MiningAdvancedUpgradeItem() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.75f,
            typeof(MiningSkill),
            0.7f         
        ) { }
    }
}