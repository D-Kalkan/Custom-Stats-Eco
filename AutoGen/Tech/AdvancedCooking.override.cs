﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Advanced Cooking")]
    [Ecopedia("Professions", "Chef", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    [RequiresSkill(typeof(ChefSkill), 0), Tag("Chef Specialty"), Tier(4)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class AdvancedCookingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced cooking techniques for producing more complex foods. Levels up by crafting advanced cooking recipes."); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 
                1,
                1 - 0.2f,
                1 - 0.25f,
                1 - 0.3f,
                1 - 0.35f,
                1 - 0.4f,
                1 - 0.45f,
                1 - 0.5f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;

        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 4; } }
    }

    [Serialized]
    [LocDisplayName("Advanced Cooking Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class AdvancedCookingSkillBook : SkillBook<AdvancedCookingSkill, AdvancedCookingSkillScroll> {}

    [Serialized]
    [LocDisplayName("Advanced Cooking Skill Scroll")]
    public partial class AdvancedCookingSkillScroll : SkillScroll<AdvancedCookingSkill, AdvancedCookingSkillBook> {}


    public partial class AdvancedCookingSkillBookRecipe : RecipeFamily
    {
        public AdvancedCookingSkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "AdvancedCooking",  //noloc
                Localizer.DoStr("Modern Advanced Cooking Research Project"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CulinaryResearchPaperAdvancedItem), 400, typeof(CookingSkill)),
                    new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 100, typeof(CookingSkill)),
                    new IngredientElement(typeof(DendrologyResearchPaperModernItem), 200, typeof(CookingSkill)),
                    new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 150, typeof(CookingSkill)),
                    new IngredientElement(typeof(GeologyResearchPaperModernItem), 200, typeof(CookingSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 100, typeof(CookingSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 50, typeof(CookingSkill)),
                    new IngredientElement(typeof(AgricultureResearchPaperAdvancedItem), 50, typeof(CookingSkill)),
                    new IngredientElement(typeof(AgricultureResearchPaperModernItem), 150, typeof(CookingSkill)),
                    new IngredientElement("Basic Research", 350, typeof(CookingSkill)), //noloc                  
                },
                new List<CraftingElement>
                {
                    new CraftingElement<AdvancedCookingSkillBook>(),
                    new CraftingElement<AdvancedCookingSkillScroll>(100)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Research 1: Advanced Cooking"), typeof(AdvancedCookingSkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
