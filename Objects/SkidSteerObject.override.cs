// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
	using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Math;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World.Blocks;
    using Eco.World;

    [Tag("Excavation")]
    public partial class SkidSteerItem : WorldObjectItem<SkidSteerObject> { }

    [Serialized]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(AirPollutionComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(VehicleToolComponent))]
    public class SkidSteerObject : PhysicsWorldObject
    {
        protected SkidSteerObject() { }
        public override LocString DisplayName                     { get { return Localizer.DoStr("Skid Steer"); } }
		public override TableTextureMode TableTexture => TableTextureMode.Metal;

        static SkidSteerObject()
        {
            WorldObject.AddOccupancy<SkidSteerObject>(new List<BlockOccupancy>(0));
        }

        private static string[] fuelTagList = new string[]
        {
            "Diesel",
        };

        private Player Driver { get { return this.GetComponent<VehicleComponent>().Driver; } }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<FuelConsumptionComponent>().Initialize(45);
            this.GetComponent<AirPollutionComponent>().Initialize(0.5f);
            this.GetComponent<VehicleComponent>().Initialize(16, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(2);
            this.GetComponent<VehicleToolComponent>().Initialize(5, 2800000, new DirtItem(),
                100, 200, 0, VehicleUtilities.GetInventoryRestriction(this), toolOnMount:true);
        }
    }
}
