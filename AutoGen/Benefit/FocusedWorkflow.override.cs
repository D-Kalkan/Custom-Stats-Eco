﻿
// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;

    public partial class FocusedWorkflowTalent : Talent
    {
        public override bool Base => true;
        public override Type TalentType { get { return typeof(CraftingTalent); } }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Composites")]
    public partial class CompositesFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public CompositesFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(CompositesFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(CompositesSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class CompositesFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(CompositesFocusedWorkflowTalentGroup); } }
        public CompositesFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: AdvancedBaking")]
    public partial class AdvancedBakingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public AdvancedBakingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AdvancedBakingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(AdvancedBakingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class AdvancedBakingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AdvancedBakingFocusedWorkflowTalentGroup); } }
        public AdvancedBakingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: CampfireCooking")]
    public partial class CampfireCookingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public CampfireCookingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(CampfireCookingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(CampfireCookingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class CampfireCookingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(CampfireCookingFocusedWorkflowTalentGroup); } }
        public CampfireCookingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: AdvancedCooking")]
    public partial class AdvancedCookingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public AdvancedCookingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AdvancedCookingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(AdvancedCookingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class AdvancedCookingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AdvancedCookingFocusedWorkflowTalentGroup); } }
        public AdvancedCookingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: AdvancedSmelting")]
    public partial class AdvancedSmeltingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public AdvancedSmeltingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AdvancedSmeltingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(AdvancedSmeltingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class AdvancedSmeltingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AdvancedSmeltingFocusedWorkflowTalentGroup); } }
        public AdvancedSmeltingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Baking")]
    public partial class BakingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public BakingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(BakingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(BakingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class BakingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(BakingFocusedWorkflowTalentGroup); } }
        public BakingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: BasicEngineering")]
    public partial class BasicEngineeringFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public BasicEngineeringFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(BasicEngineeringFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(BasicEngineeringSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class BasicEngineeringFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(BasicEngineeringFocusedWorkflowTalentGroup); } }
        public BasicEngineeringFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Pottery")]
    public partial class PotteryFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public PotteryFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(PotteryFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(PotterySkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class PotteryFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PotteryFocusedWorkflowTalentGroup); } }
        public PotteryFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Butchery")]
    public partial class ButcheryFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public ButcheryFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(ButcheryFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(HuntingSkill);
            this.Level = 4;
        }
    }

    [Serialized]
    public partial class ButcheryFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(ButcheryFocusedWorkflowTalentGroup); } }
        public ButcheryFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: AdvancedMasonry")]
    public partial class AdvancedMasonryFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public AdvancedMasonryFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(AdvancedMasonryFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(AdvancedMasonrySkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class AdvancedMasonryFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(AdvancedMasonryFocusedWorkflowTalentGroup); } }
        public AdvancedMasonryFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Cooking")]
    public partial class CookingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public CookingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(CookingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(CookingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class CookingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(CookingFocusedWorkflowTalentGroup); } }
        public CookingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: CuttingEdgeCooking")]
    public partial class CuttingEdgeCookingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public CuttingEdgeCookingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(CuttingEdgeCookingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(CuttingEdgeCookingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class CuttingEdgeCookingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(CuttingEdgeCookingFocusedWorkflowTalentGroup); } }
        public CuttingEdgeCookingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Electronics")]
    public partial class ElectronicsFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public ElectronicsFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(ElectronicsFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(ElectronicsSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class ElectronicsFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(ElectronicsFocusedWorkflowTalentGroup); } }
        public ElectronicsFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Fertilizers")]
    public partial class FertilizersFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public FertilizersFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(FertilizersFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(FertilizersSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class FertilizersFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(FertilizersFocusedWorkflowTalentGroup); } }
        public FertilizersFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Glassworking")]
    public partial class GlassworkingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public GlassworkingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(GlassworkingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(GlassworkingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class GlassworkingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(GlassworkingFocusedWorkflowTalentGroup); } }
        public GlassworkingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Industry")]
    public partial class IndustryFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public IndustryFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(IndustryFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(IndustrySkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class IndustryFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(IndustryFocusedWorkflowTalentGroup); } }
        public IndustryFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Mechanics")]
    public partial class MechanicsFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public MechanicsFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(MechanicsFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(MechanicsSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class MechanicsFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MechanicsFocusedWorkflowTalentGroup); } }
        public MechanicsFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Milling")]
    public partial class MillingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public MillingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(MillingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(MillingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class MillingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MillingFocusedWorkflowTalentGroup); } }
        public MillingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Masonry")]
    public partial class MasonryFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public MasonryFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(MasonryFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(MasonrySkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class MasonryFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(MasonryFocusedWorkflowTalentGroup); } }
        public MasonryFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: OilDrilling")]
    public partial class OilDrillingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public OilDrillingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(OilDrillingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(OilDrillingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class OilDrillingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(OilDrillingFocusedWorkflowTalentGroup); } }
        public OilDrillingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: PaperMilling")]
    public partial class PaperMillingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public PaperMillingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(PaperMillingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(PaperMillingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class PaperMillingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(PaperMillingFocusedWorkflowTalentGroup); } }
        public PaperMillingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Smelting")]
    public partial class SmeltingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public SmeltingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(SmeltingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(SmeltingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class SmeltingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(SmeltingFocusedWorkflowTalentGroup); } }
        public SmeltingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Tailoring")]
    public partial class TailoringFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public TailoringFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(TailoringFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(TailoringSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class TailoringFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(TailoringFocusedWorkflowTalentGroup); } }
        public TailoringFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Farming")]
    public partial class FarmingFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public FarmingFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(FarmingFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(FarmingSkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class FarmingFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(FarmingFocusedWorkflowTalentGroup); } }
        public FarmingFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }

    [Serialized]
    [LocDisplayName("Focused Workflow: Carpentry")]
    public partial class CarpentryFocusedWorkflowTalentGroup : TalentGroup
    {
        public override LocString DisplayDescription { get; } = Localizer.DoStr("Doubles the speed of related tables when alone.");

        public CarpentryFocusedWorkflowTalentGroup()
        {
            Talents = new Type[]
            {
                typeof(CarpentryFocusedSpeedTalent),
            };
            this.OwningSkill = typeof(CarpentrySkill);
            this.Level = 3;
        }
    }

    [Serialized]
    public partial class CarpentryFocusedSpeedTalent : FocusedWorkflowTalent
    {
        public override bool Base { get { return false; } }
        public override Type TalentGroupType { get { return typeof(CarpentryFocusedWorkflowTalentGroup); } }
        public CarpentryFocusedSpeedTalent()
        {
            this.Value = 0.5f;
        }
    }
}