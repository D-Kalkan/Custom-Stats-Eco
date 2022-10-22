// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Utils;
    using Eco.Gameplay.Aliases;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Economy.Contracts;
    using Eco.Gameplay.GameActions;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.UI;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Localization.ConstLocs;
    using Eco.Shared.Math;
    using Eco.Shared.Utils;
    using Eco.Shared.Voxel;

    [Category("Tools")]
    [Tag("Primitive Tool", 1)]
    [CarryTypesLimited]
    public partial class PropertyToolItem : ToolItem
    {
        static readonly IDynamicValue SkilledRepairCostValue               = new ConstantValue(1);
        public override IDynamicValue SkilledRepairCost                   => SkilledRepairCostValue;
        static InteractResult         ErrorAlreadyPublic                  => InteractResult.Failure(Localizer.DoStr("This plot is already public."));
        static InteractResult         ErrorNoNearby                       => InteractResult.Failure(Localizer.DoStr("There are no owned deeds nearby."));
        static InteractResult         ErrorBelongsTo(string owner)        => InteractResult.Failure(Localizer.Do($"This property belongs to {owner}."));
        public override float         InteractDistance                    => DefaultInteractDistance.Placement;
        public override float         DurabilityRate                      => 0f;
        public override bool          PreventUseWithCarriedItems          => true;

        public static InteractResult DoClaim(Deed deed, User actor, PlotPos plotPos, bool notify = true)
        {   
            // Try to perform the claiming action
            Result claimResult = AtomicActions.ClaimPropertyNow(deed, actor, plotPos, ClaimedOrUnclaimed.ClaimingLand, false, notify);
            if (!claimResult.Success && !deed.OwnedObjects.Any()) PropertyManager.TryRemoveDeed(deed);
            return (InteractResult)claimResult;
        }

        public static async void ClaimWithDialog(Player player, IEnumerable<Deed> nearbyDeeds, PlotPos plotPos)
        {   // Get names and show the dialog
            var options    =     new List<string>(); foreach (var d in nearbyDeeds) options.Add(d.Name);
            var selection  =     await player.OptionBox(Localizer.DoStr(PlotLocs.SelectDeedForPlot), options);
            if (selection != -1) DoClaim(nearbyDeeds.ElementAt(selection), player.User, plotPos);  // If the dialog was not canceled.
        }
        
        public static async void ChangeWithDialog(Player player, IEnumerable<Deed> nearbyDeeds, Vector2i position)
        {   // Get names and show the dialog
            var plot = PropertyManager.GetPlotFromWorldPos(position);
            if (plot.Owners?.ContainsUser(player.User) != true) return;

            var options    =     new List<string>(); foreach (var d in nearbyDeeds) options.Add(d.Name);
            var selection  =     await player.OptionBox(Localizer.DoStr(PlotLocs.SelectDeedForPlot), options);
            if (selection != -1)
            {
                var initialDeed = plot.Deed;
                var targetDeed  = nearbyDeeds.ElementAt(selection);
                if (targetDeed != initialDeed) initialDeed.MoveOwnable(player, plot, targetDeed); 
            }
        }

        // if player is looking at interactable item show its tooltip, otherwise show tooltip for claiming land
        public override IEnumerable<InteractionDesc> GetInteractiveDescs(InteractionContext context) => context.HasTarget ? base.GetInteractiveDescs(context) : ClaimingUtils.GetInteractiveDescs(context);
        public override InteractResult OnActRight(InteractionContext context)                        => ClaimingUtils.Claim(context);

        public static async void DeleteWithDialog(Player player, Deed deed)
        {
            try
            {
                if (await player?.ConfirmBox(Localizer.Do($"Do you wish to completely unclaim {deed?.MarkedUpName}?")))
                    deed?.DeleteDeed(player);
            }
            catch (Exception e)
            {
                Log.WriteException(e);
            }
        }

        private async void ConfirmUnclaim(Player player, LocString message, PlotPos plotPos)
        {
            var confirm = await player.ConfirmBox(message);
            if (confirm) PropertyManager.TryUnclaim(new GameActionPack(), player.User, player.User.Inventory, plotPos, autoPerform: true);
        }

        // Hit to unclaim
        public override InteractResult OnActLeft(InteractionContext context)
        {
            PlotPos? plotPos = ClaimingUtils.GetClaimingPlotPos(context);
            Player player = context.Player;


            if (!plotPos.HasValue) return InteractResult.NoOp;
            var plot = PropertyManager.GetPlotFromPlotPos(plotPos.Value);
            var deed = plot?.Deed;
            if (deed == null) return ErrorAlreadyPublic;

            // shift + click
            if (context.Modifier == InteractionModifier.Shift)
            {
                var nearbyDeeds = PropertyManager.ConnectedDeeds(player.User, plotPos.Value)?.Where(d => d != plot.Deed); //Nearby deeds, ignore same deed as initial plot
                if (nearbyDeeds != null && nearbyDeeds.Any()) ClaimingUtils.ChangeWithDialog(player, nearbyDeeds, plotPos.Value);
                else return ErrorNoNearby;
                return InteractResult.NoOp;
            }

            // ctrl + click
            else if (context.Modifier == InteractionModifier.Ctrl)
            {
                DeleteWithDialog(player, deed);
                return InteractResult.NoOp; //
            }

            // regular click
            else
            {
                var deedsAfterUnclaim = deed.GetContiguousPartsWithAlterations(null, new List<PlotPos> { plotPos.Value });
                if (deedsAfterUnclaim.Count > 1)
                {
                    this.ConfirmUnclaim(player, Localizer.Do($"Unclaiming this plot will split {deed.Name} into {deedsAfterUnclaim.Count()} because property must be contiguous on a deed. Do you want to continue?"), plotPos.Value);
                    return InteractResult.NoOp;
                }
                var result = (InteractResult)PropertyManager.TryUnclaim(new GameActionPack(), player.User, player.User.Inventory, plotPos.Value, autoPerform: true);
                return result;
            }
        }


        // Interact to examine
        public override InteractResult OnActInteract(InteractionContext context)
        {
            PlotPos? position = ClaimingUtils.GetClaimingPlotPos(context);

            if (!position.HasValue)
                return InteractResult.NoOp;

            Deed deed = PropertyManager.GetDeedPlotPos(position.Value);

            if (deed != null)
            {
                deed.OpenAuthorizationMenuOn(context.Player);
                return InteractResult.Success;
            }

            return base.OnActLeft(context);
        }
        
        public override void OnSelected(Player player)
        {
            base.OnSelected(player);
            player?.SetPropertyClaimingMode(PropertyClaimStyle.LegacyClaim);
        }
        
        public override void OnDeselected(Player player)
        {
            base.OnDeselected(player);
            player?.StopPropertyClaimingMode();
        }
    }
}
