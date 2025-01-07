using AdminToys;
using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Features.Toys;
using Exiled.Events;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core;
using UnityEngine;
using Light = Exiled.API.Features.Toys.Light;

namespace Slot_Machine.Handlers {
    public class ServerHandler {
        
        PluginCore Instance = new PluginCore();

        public Primitive[] CISlots;
        public Primitive[] NTFSlots;
        
        public void OnRoundStarted() {
            Log.Info("sawning primitives at " + Config.CISlotPos + " and " + Config.NTFSlotPos);
            
            CISlots = SpawnSlotMachine(Config.CISlotPos, 180f);
            NTFSlots = SpawnSlotMachine(Config.NTFSlotPos, 90f);
        }

        public Primitive[] SpawnSlotMachine(Vector3 position, float rotOffset) {
            Primitive[] m = new Primitive[17];
            
            //list of sizes {Pos, Rot, Scl}
            Vector3[][] o = new Vector3[][] {
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, 0f, -0.125f), new(0f, 0f, 0f), new(1f, 2f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, -0.625f, -0.12f), new(0f, 0f, 0f), new(0.95f, 0.75f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.4f, -0.125f, -0.125f), new(0f, 0f, 90f), new(0.25f, 0.25f, 0.25f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.575f, 0.25f, -0.125f), new(0f, 0f, 0f), new(0.05f, 0.25f, 0.05f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.575f, 0.5f, -0.125f), new(0f, 0f, 0f), new(0.1f, 0.1f, 0.1f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.3f, 0.25f, 0f), new(135f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.3f, 0.25f, 0f), new(90f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.3f, 0.25f, 0f), new(45f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.3f, 0.25f, 0f), new(0, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, 0.25f, 0f), new(135f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, 0.25f, 0f), new(90f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, 0.25f, 0f), new(45f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, 0.25f, 0f), new(0, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(-0.3f, 0.25f, 0f), new(135f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(-0.3f, 0.25f, 0f), new(90f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(-0.3f, 0.25f, 0f), new(45f, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(-0.3f, 0.25f, 0f), new(0, 0f, 0f), new(0.2f, 0.31f, 0.75f)},
            };
            
            //addlight 
            Light.Create(position, Vector3.zero, Vector3.one, true, Color.cyan);
            
            //Create body
            m[0] = Primitive.Create(PrimitiveType.Cube, position + o[0][0], o[0][1] + Vector3.up * rotOffset, o[0][2],true, new Color(1f, 0.4f, 0f));
            m[1] = Primitive.Create(PrimitiveType.Cube, position + o[1][0], o[1][1] + Vector3.up * rotOffset, o[1][2], true, Color.black);
            
            //Create lever
            m[2] = Primitive.Create(PrimitiveType.Cylinder, position + o[2][0], o[2][1] + Vector3.up * rotOffset, o[2][2], true, Color.grey);
            m[3] = Primitive.Create(PrimitiveType.Cylinder, position + o[3][0], o[3][1] + Vector3.up * rotOffset, o[3][2], true, Color.grey);
            m[4] = Primitive.Create(PrimitiveType.Sphere, position + o[4][0], o[4][1] + Vector3.up * rotOffset, o[4][2], true, Color.red);
            
            //Create Wheels
            for (int i = 5; i < 17; i++) {
                Log.Info(i.ToString() + o[i][1]);
                m[i] = Primitive.Create(PrimitiveType.Cube, position + o[i][0], o[i][1] + Vector3.up * rotOffset, o[i][2]);
                switch (i%4) {
                    case 0:
                        m[i].Color = Color.magenta*3f;
                        break;
                    case 1:
                        m[i].Color = Color.green * 1.5f;
                        break;
                    case 2:
                        m[i].Color = Color.blue * 1.5f;
                        break;
                    case 3:
                        m[i].Color = Color.red * 1.5f;
                        break;
                }
            }
            
            return m;
        }
        
    }
}