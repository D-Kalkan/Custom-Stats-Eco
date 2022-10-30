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


    [RequiresSkill(typeof(AdvancedBakingSkill), 1)]
    public partial class CulinaryResaerchPaperModernBakingRecipe : RecipeFamily
    {
        public CulinaryResaerchPaperModernBakingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CulinaryResearchPaperModern",  //noloc
                Localizer.DoStr("Culinary Research Paper Modern Baking"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(FruitTartItem), 10, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                    new IngredientElement(typeof(PupusasItem), 10, typeof(AdvancedBakingSkill), typeof(AdvancedBakingLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CulinaryResearchPaperModernItem>(),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 6;
            this.LaborInCalories = CreateLaborInCaloriesValue(600, typeof(AdvancedBakingSkill));
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Culinary Research Paper Modern Baking"), typeof(CulinaryResaerchPaperModernBakingRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ResearchTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
