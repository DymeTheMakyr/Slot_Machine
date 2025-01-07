using AdminToys;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Features.Toys;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core;
using UnityEngine;

namespace Slot_Machine.Handlers {
    public class ServerHandler {
        
        PluginCore Instance = new PluginCore();
        
        public void OnRoundStarted() {
            Log.Info("sawning primitives at " + Config.CISlotPos + " and " + Config.NTFSlotPos);
            Primitive CISlot = Primitive.Create(PrimitiveType.Cube, Config.CISlotPos, Vector3.zero, new Vector3(1, 2, 1));
            Primitive NTFSlot = Primitive.Create(PrimitiveType.Cube, Config.NTFSlotPos, Vector3.zero, new Vector3(1, 2, 1));
            Log.Info("done spawning primitives at " + CISlot.Position + " | " + CISlot.Scale + " and " + NTFSlot.Position + " | " + NTFSlot.Scale);
        }

        public Primitive[] SpawnSlotMachine(Vector3 position, float rotOffset) {
            Primitive[] m = new Primitive[17];

            m[0] = Primitive.Create(PrimitiveType.Cube, position + (Vector3.forward * -0.25f), new Vector3(0f, rotOffset, 0f), new Vector3(1f, 2f, 0.75f));//Body
            m[1] = Primitive.Create(PrimitiveType.Cube, position +  new Vector3(0f, -1.25f, -0.24f), new Vector3(0f, rotOffset, 0f), new Vector3(0.95f, 0.75f, 0.75f));
            m[2] = Primitive.Create(PrimitiveType.Cylinder, position + new Vector3(0.8f, -0.25f, -0.2f), new Vector3(0f, rotOffset, 90f), new Vector3(0.95f, 0.75f, 0.75f));
            m[3] = Primitive.Create(PrimitiveType.Cylinder, position + 
            
            return m;
        }
        
    }
}