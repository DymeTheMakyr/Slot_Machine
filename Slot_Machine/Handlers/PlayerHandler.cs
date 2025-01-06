using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core;

namespace Slot_Machine.Handlers {
    public class PlayerHandler {
        public void OnItemDropped(DroppedItemEventArgs ev) {
            Log.Info(""+ev.Player.Position);
        }
    }
}