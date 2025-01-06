using AdminToys;
using Exiled.API.Features;
using Exiled.API.Features.Toys;
using UnityEngine;
using Log = PluginAPI.Core.Log;
using Player = Exiled.Events.Handlers.Player;

namespace Slot_Machine {
    public class PluginCore : Plugin<Config> {
        public static PluginCore Instance;

        private Handlers.PlayerHandler playerHandler;
        
        public override void OnEnabled() {
            base.OnEnabled();
            //register events
            playerHandler = new();
            Player.DroppedItem += playerHandler.OnItemDropped;
            //spawn slot machines
            Primitive CISlot = Primitive.Create(PrimitiveType.Cube, PrimitiveFlags.Collidable, Config.CISlotPos, Vector3.zero, new Vector3(1, 2, 1), true, new Color(0,0,0,0) );
            Primitive NTFSlot = Primitive.Create(PrimitiveType.Cube, PrimitiveFlags.Collidable, Config.NTFSlotPos, Vector3.zero, new Vector3(1, 2, 1), true, new Color(0,0,0,0) );
        }

        public override void OnDisabled() {
            base.OnDisabled();
            Player.DroppedItem -= playerHandler.OnItemDropped;
            playerHandler = null;
        }
    }
}