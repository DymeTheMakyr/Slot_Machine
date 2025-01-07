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

        public Primitive[] CISlots;
        public Primitive[] NTFSlots;
        
        public void OnRoundStarted() {
            Log.Info("sawning primitives at " + Config.CISlotPos + " and " + Config.NTFSlotPos);
            Primitive CISlot = Primitive.Create(PrimitiveType.Cube, Config.CISlotPos, Vector3.zero, new Vector3(1, 2, 1));
            Primitive NTFSlot = Primitive.Create(PrimitiveType.Cube, Config.NTFSlotPos, Vector3.zero, new Vector3(1, 2, 1));
            Log.Info("done spawning primitives at " + CISlot.Position + " | " + CISlot.Scale + " and " + NTFSlot.Position + " | " + NTFSlot.Scale);
            
            CISlots = SpawnSlotMachine(Config.CISlotPos, 0);
            NTFSlots = SpawnSlotMachine(Config.NTFSlotPos, 0);
        }

        public Primitive[] SpawnSlotMachine(Vector3 position, float rotOffset) {
            Primitive[] m = new Primitive[17];
            
            //list of sizes {Pos, Rot, Scl}
            Vector3[][] o = new Vector3[][] {
                new Vector3[]{new(0f, 0f, -0.25f), new(0f, 0f, 0f), new(1f, 2f, 0.75f)},
                new Vector3[]{new(0f, -1.25f, -0.24f), new(0f, 0f, 0f), new(0.95f, 2f, 0.75f)},
                new Vector3[]{new(0.8f, -0.25f, -0.2f), new(0f, 0f, 90f), new(0.95f, 2f, 0.75f)},
                new Vector3[]{new(1.15f, 0.5f, -0.25f), new(0f, 0f, 0f), new(0.05f, 0.5f, 0.05f)},
                new Vector3[]{new(1.15f, 1f, -0.25f), new(0f, 0f, 0f), new(0.1f, 0.1f, 0.1f)},
                new Vector3[]{new(0.6f, 0.5f, 0f), new(135f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0.6f, 0.5f, 0f), new(90f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0.6f, 0.5f, 0f), new(45f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0.6f, 0.5f, 0f), new(0, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0f, 0.5f, 0f), new(135f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0f, 0.5f, 0f), new(90f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0f, 0.5f, 0f), new(45f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(0f, 0.5f, 0f), new(0, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(-0.6f, 0.5f, 0f), new(135f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(-0.6f, 0.5f, 0f), new(90f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(-0.6f, 0.5f, 0f), new(45f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{new(-0.6f, 0.5f, 0f), new(0, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
            };
            
            //applying rotOffset to coords
            foreach (Vector3[] v in o) {
                Vector2 t = new Vector2(v[0].x, v[0].z);
                t.RotateAroundZ(rotOffset);
                v[0].x = t.x;
                v[0].z = t.y;
            }

            //Create body
            m[0] = Primitive.Create(PrimitiveType.Cube, position + o[0][0], o[0][1] + Vector3.up * rotOffset, o[0][2]);
            m[1] = Primitive.Create(PrimitiveType.Cube, position + o[1][0], o[1][1] + Vector3.up * rotOffset, o[1][2]);
            
            //Create lever
            m[2] = Primitive.Create(PrimitiveType.Cube, position + o[2][0], o[2][1] + Vector3.up * rotOffset, o[2][2]);
            m[3] = Primitive.Create(PrimitiveType.Cube, position + o[3][0], o[3][1] + Vector3.up * rotOffset, o[3][2]);
            m[4] = Primitive.Create(PrimitiveType.Cube, position + o[4][0], o[4][1] + Vector3.up * rotOffset, o[4][2]);
            
            //Create Wheels
            for (int i = 5; i < 17; i++) {
                m[i] = Primitive.Create(PrimitiveType.Cube, position + o[i][0], o[i][1] + Vector3.up * rotOffset, o[i][2]);
            }
            
            return m;
        }
        
    }
}