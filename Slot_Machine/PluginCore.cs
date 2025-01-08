using AdminToys;
using Exiled.API.Features;
using Exiled.API.Features.Toys;
using Slot_Machine.Classes;
using UnityEngine;
using Light = Exiled.API.Features.Toys.Light;
using Log = PluginAPI.Core.Log;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace Slot_Machine {
    public class PluginCore : Plugin<Config> {
        public static PluginCore Instance;

        public static SlotMachine CISlots;
        public static SlotMachine NTFSlots;
        
        private Handlers.PlayerHandler playerHandler;
        private Handlers.ServerHandler serverHandler;        
        
        public override void OnEnabled() {
            base.OnEnabled();
            //register events
            playerHandler = new();
            serverHandler = new();
            Player.DroppedItem += playerHandler.OnItemDropped;
            Server.RoundStarted += serverHandler.OnRoundStarted;
        }

        public override void OnDisabled() {
            base.OnDisabled();
            Player.DroppedItem -= playerHandler.OnItemDropped;
            Server.RoundStarted -= serverHandler.OnRoundStarted;
            playerHandler = null;
            serverHandler = null;
        }
    }
}