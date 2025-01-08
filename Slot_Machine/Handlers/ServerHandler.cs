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
            PluginCore.CISlots = SpawnSlotMachine(Config.CISlotPos, 180f);
            PluginCore.NTFSlots = SpawnSlotMachine(Config.NTFSlotPos, 90f);
        }

        private SlotMachine SpawnSlotMachine(Vector3 position, float rotOffset) {
            Primitive[] m = new Primitive[20];
            Light[] l = new Light[3];
            
            //list of sizes {Pos, Rot, Scl}
            //0-1 Body
            //2-4 Lever
            //5-16 Slot Wheels
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
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(-0.3f, 0.4f, 0.5f), Vector3.zero, Vector3.one},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0f, 0.4f, 0.5f), Vector3.zero, Vector3.one},
                new Vector3[]{Quaternion.AngleAxis(rotOffset, Vector3.up) * new Vector3(0.3f, 0.4f, 0.5f), Vector3.zero, Vector3.one},
            };
            //Create Main Body
            m[0] = Primitive.Create(PrimitiveType.Cube, position + o[0][0], o[0][1] + Vector3.up * rotOffset, o[0][2],true, new Color(1f, 0.4f, 0f));
            m[1] = Primitive.Create(PrimitiveType.Cube, position + o[1][0], o[1][1] + Vector3.up * rotOffset, o[1][2], true, Color.black);
            //Create Lever
            m[2] = Primitive.Create(PrimitiveType.Cylinder, position + o[2][0], o[2][1] + Vector3.up * rotOffset, o[2][2], true, Color.grey);
            m[3] = Primitive.Create(PrimitiveType.Cylinder, position + o[3][0], o[3][1] + Vector3.up * rotOffset, o[3][2], true, Color.grey);
            m[4] = Primitive.Create(PrimitiveType.Sphere, position + o[4][0], o[4][1] + Vector3.up * rotOffset, o[4][2], true, Color.red);
            //Create Wheels
            for (int i = 5; i < 17; i++) {
                m[i] = Primitive.Create(PrimitiveType.Cube, position + o[i][0], o[i][1] + Vector3.up * rotOffset, o[i][2]);
               
                //Set colours so wheels will be gambleable
                switch (i%4) {
                    case 0:
                        m[i].Color = Config.pink;
                        break;
                    case 1:
                        m[i].Color = Config.green;
                        break;
                    case 2:
                        m[i].Color = Config.yellow;
                        break;
                    case 3:
                        m[i].Color = Config.red;
                        break;
                }
            }
            //Set slot initial position
            for (int i = 9; i < 13; i++) {
                m[i].Rotation *= Quaternion.Euler(45f, 0, 0);
            }
            for (int i = 13; i < 17; i++) {
                m[i].Rotation *= Quaternion.Euler(90f, 0f, 0f);
            }
            //Add Lights
            l[0] = Light.Create(o[17][0] + position, o[17][1], o[17][2], true, Config.warmWhite);
            l[1] = Light.Create(o[18][0] + position, o[18][1], o[18][2], true, Config.warmWhite);
            l[2] = Light.Create(o[19][0] + position, o[19][1], o[19][2], true, Config.warmWhite);
            l[0].Intensity = 0.25f;
            l[1].Intensity = 0.25f;
            l[2].Intensity = 0.25f;
            return new SlotMachine(m, l, [0, 1, 2]);
        }
        
    }
}