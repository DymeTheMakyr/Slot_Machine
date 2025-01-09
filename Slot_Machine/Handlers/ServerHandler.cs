using AdminToys;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Features.Toys;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core;
using Slot_Machine.Classes;
using UnityEngine;
using Light = Exiled.API.Features.Toys.Light;

namespace Slot_Machine.Handlers {
    public class ServerHandler {

        PluginCore Inst = PluginCore.Instance;

        public void OnRoundStarted() {
            Log.Info("sawning primitives at " + Config.CISlotPos + " and " + Config.NTFSlotPos);
            PluginCore.CISlots = SlotMachine.SpawnSlotMachine(Config.CISlotPos, 180f);
            PluginCore.NTFSlots = SlotMachine.SpawnSlotMachine(Config.NTFSlotPos, 90f);
        }
    }
}