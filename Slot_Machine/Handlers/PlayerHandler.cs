using System;
using System.Collections.Generic;
using Exiled.API.Features.Items;
using Exiled.API.Features.Toys;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Slot_Machine.Classes;
using UnityEngine;
using MEC;
using PluginAPI.Core;
using Utf8Json.Unity;
using Light = Exiled.API.Features.Toys.Light;
using Random = UnityEngine.Random;

namespace Slot_Machine.Handlers {
    public class PlayerHandler {
        //Tierlists for gambloiing
        public void OnItemDropped(DroppedItemEventArgs ev) {
            ItemType item = ev.Pickup.Type;  //get item
            Vector3 position = Vector3.negativeInfinity;  //set pos as "null"
            Vector3 rotation = Vector3.negativeInfinity;  //set rot as "null"

            int result = 0;
            
            //check if drop is within 1m of slot machine and sets location to nearest slot
            if ((ev.Pickup.Position - Config.CISlotPos).magnitude < Config.pickupRange) {
                ev.Pickup.Destroy();
                result = -1;
                Log.Info("start");
                Log.Info(result.ToString());
                position = Config.CISlotPos;
                rotation = Quaternion.AngleAxis(PluginCore.CISlots.Body[0].Rotation.y, Vector3.up) * Vector3.forward;
                Timing.RunCoroutine(SlotMachine.Gamble(PluginCore.CISlots, item, position, rotation));
            }
            else if ((ev.Pickup.Position - Config.NTFSlotPos).magnitude < Config.pickupRange) {
                ev.Pickup.Destroy();
                result = -1;
                position = Config.NTFSlotPos;
                rotation = Quaternion.AngleAxis(PluginCore.NTFSlots.Body[0].Rotation.y, Vector3.up) * Vector3.forward;
                Timing.RunCoroutine(SlotMachine.Gamble(PluginCore.NTFSlots, item, position, rotation));
            }
        }
    }
}