using AdminToys;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Features.Toys;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core;
using UnityEngine;

namespace Slot_Machine.Handlers {
    public class PlayerHandler {
        public void OnItemDropped(DroppedItemEventArgs ev) {
            Log.Info(""+ev.Player.Position);
            // Log.Info("sawning primitives at " + Config.CISlotPos + " and " + Config.NTFSlotPos);
            // Primitive CISlot = Primitive.Create(PrimitiveType.Cube, ev.Player.Position, Vector3.zero, new Vector3(1, 2, 1), false);
            // Primitive NTFSlot = Primitive.Create(PrimitiveType.Cube, ev.Player.Position, Vector3.zero, new Vector3(1, 2, 1), false);
            // Log.Info("done spawning primitives at " + CISlot.Position + " and " + NTFSlot.Position);
            // CISlot.Spawn();
            // NTFSlot.Spawn();
        }
    }
}