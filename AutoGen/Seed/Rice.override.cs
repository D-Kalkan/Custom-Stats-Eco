﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Gameplay.Blocks;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.SearchAndSelect;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Players;
    using System.ComponentModel;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Rice")]
    [Yield(typeof(RiceItem), typeof(FarmingSkill), new float[] { 1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f })]
    [Crop]
    [Weight(10)]
    [StartsDiscovered]
    [Tag("Grain", 1)]
    [Tag("Raw Food", 1)]
    [Tag("Crop", 1)]
    [Tag("Crop Seed", 1)]
    public partial class RiceItem : SeedItem
    {
        static RiceItem() { }

        private static Nutrients nutrition = new Nutrients() { Carbs = 7, Fat = 0, Protein = 1, Vitamins = 0 };

        public override LocString DisplayDescription    => Localizer.DoStr("Plant to grow rice.");
        public override LocString SpeciesName           => Localizer.DoStr("Rice");

        public override float Calories                  => 15;
        public override Nutrients Nutrition             => nutrition;
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(72);
    }


    [Serialized]
    [LocDisplayName("Rice Pack")]
    [Category("Hidden")]
    [Weight(10)]
    public partial class RicePackItem : SeedPackItem
    {
        static RicePackItem() { }

        public override LocString DisplayDescription { get { return Localizer.DoStr("Plant to grow rice."); } }
        public override LocString SpeciesName        { get { return Localizer.DoStr("Rice"); } }
    }

}
