using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features.Items;
using Exiled.API.Features.Toys;
using MEC;
using UnityEngine;
using Light = Exiled.API.Features.Toys.Light;

namespace Slot_Machine.Classes;

public class SlotMachine {
    public Primitive[] Body = new Primitive[2];
    public Primitive[] Lever = new Primitive[3];
    public Primitive[] Wheels = new Primitive[12];
    public Light[] Lights = new Light[3];
    public int[] Index = new int[3];

    public static ItemType[] GunTiersNTF = [
        ItemType.GunFSP9,
        ItemType.GunCrossvec,
        ItemType.GunE11SR,
        ItemType.GunFRMG0,
        ItemType.MicroHID
    ];

    public static ItemType[] GunTiersCI = [
        ItemType.GunAK,
        ItemType.GunShotgun,
        ItemType.GunA7,
        ItemType.GunLogicer,
        ItemType.ParticleDisruptor
    ];
        
    public static ItemType[] GunTiersPistol = [
        ItemType.GunCOM15,
        ItemType.GunCOM18,
        ItemType.GunRevolver,
        ItemType.GunCom45
    ];

    public static ItemType[] ArmourTiers = [
        ItemType.ArmorLight,
        ItemType.ArmorCombat,
        ItemType.ArmorHeavy,
        ItemType.AntiSCP207
    ];

    public static ItemType[] HealTiers = [
        ItemType.Painkillers,
        ItemType.Medkit,
        ItemType.Adrenaline,
        ItemType.SCP500
    ];

    public static ItemType[] GrenadeTiers = [
        ItemType.GrenadeFlash,
        ItemType.GrenadeHE,
        ItemType.Coal, //placeholder, when selected drop BoogieBomb instead
        ItemType.SCP2176
    ];

    
    public SlotMachine(Primitive[] body, Light[] lights, int[] index) {
        Body = body.Where(x => body.IndexOf(x) < 2).ToArray();
        Lever = body.Where(x => body.IndexOf(x) < 5 && body.IndexOf(x) > 1).ToArray();
        Wheels = body.Where(x => body.IndexOf(x) > 4).ToArray();
        Lights = lights;
        Index = index;
    }
    public static SlotMachine SpawnSlotMachine(Vector3 position, float rotOffset) {
        Primitive[] m = new Primitive[17];
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
    
    public static IEnumerator<float> Gamble(SlotMachine sm, ItemType item ,Vector3 position, Vector3 rotation) {
        int[] indicies = [Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8)];
        
        int result = 0;
        if (indicies[0] == indicies[1] && indicies[0] == indicies[2]) if (indicies[0] == 0) {
                result = 2;
            }
            else {
                result = 1;
            }
        
        //Lever anim
        float index = 0;
        Vector3 init = sm.Lever[1].Position;
        yield return Timing.WaitUntilDone(Timing.CallContinuously(1f, () => {
            float angle = Mathf.Cos(index * 360f);
            Vector3 init = sm.Lever[1].Rotation.eulerAngles;
            sm.Lever[1].Rotation = Quaternion.Euler(angle, init.y, init.z);
            sm.Lever[1].Position = Quaternion.AngleAxis(angle, Vector3.right) * (init - Config.CISlotPos) + Config.CISlotPos;
            index += Timing.DeltaTime;
        })); 
        
        //wheels will spin for 4s 4.5s 5s and will stop at randomly generated index
        
        Timing.CallContinuously(4f + 0.063f*indicies[0], () => {
            for (int i = 0; i < 12; i++) {
                sm.Wheels[i].Rotation *= Quaternion.Euler(720f * Timing.DeltaTime, 0f, 0f);
            }
        });
        
        Timing.CallContinuously(4.5f + 0.063f*indicies[1], () => {
            for (int i = 4; i < 12; i++) {
                sm.Wheels[i].Rotation *= Quaternion.Euler(720f * Timing.DeltaTime, 0f, 0f);
            }
        });
        
        CoroutineHandle longestSpin = Timing.CallContinuously(5f + 0.063f*indicies[2], () => {
            for (int i = 8; i < 12; i++) {
                sm.Wheels[i].Rotation *= Quaternion.Euler(720f * Timing.DeltaTime, 0f, 0f);
            }
        });
        
        yield return Timing.WaitUntilDone(longestSpin);
        
        if (position != Vector3.negativeInfinity && rotation != Vector3.negativeInfinity){
            if (result == 2) {
                //play jackpot sound
                //give pocket nuke
            }
            else if (result == 1) {
                //play win sound
                ItemType[] tier = [];
                if (GunTiersNTF.Contains(item)) {
                    tier = GunTiersNTF;
                }
                else if (GunTiersCI.Contains(item)) {
                    tier = GunTiersCI;
                }
                else if (GunTiersPistol.Contains(item)) {
                    tier = GunTiersPistol;
                }
                else if (ArmourTiers.Contains(item)) {
                    tier = ArmourTiers;
                }
                else if (HealTiers.Contains(item)) {
                    tier = HealTiers;
                }
                else if (GrenadeTiers.Contains(item)) {
                    tier = GrenadeTiers;
                }

                int i = tier.IndexOf(item);
                if (i != tier.Length - 1) {
                    i++;
                }
                
                Item.Create(tier[i + 1]).CreatePickup(position + rotation);
            }
            else {
                //play fail sound
            }
        }
        yield return 0;
    }
}