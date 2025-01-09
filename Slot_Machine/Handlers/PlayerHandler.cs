using System;
using System.Collections.Generic;
using Exiled.API.Features.Items;
using Exiled.API.Features.Toys;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Slot_Machine.Classes;
using UnityEngine;
using MEC;
using PluginAPI.Core;
using Utf8Json.Unity;
using Light = Exiled.API.Features.Toys.Light;
using Random = UnityEngine.Random;

namespace Slot_Machine.Handlers {
    public class PlayerHandler {
        private PluginCore Inst = PluginCore.Instance;
        
        //Tierlists for gambloiing
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

        public void OnItemDropped(DroppedItemEventArgs ev) {
            ItemType item = ev.Pickup.Type;  //get item
            Vector3 position = Vector3.negativeInfinity;  //set pos as "null"
            Vector3 rotation = Vector3.negativeInfinity;  //set rot as "null"

            int result = 0;
            
            //check if drop is within 1m of slot machine and sets location to nearest slot
            if ((ev.Pickup.Position - Config.CISlotPos).magnitude < Config.pickupRange) {
                ev.Pickup.Destroy();
                result = -1;
                Log.Info("start");
                Log.Info(result.ToString());
                position = Config.CISlotPos;
                rotation = Quaternion.AngleAxis(PluginCore.CISlots.Body[0].Rotation.y, Vector3.up) * Vector3.forward;
                Timing.RunCoroutine(Gamble(PluginCore.CISlots, item, position, rotation));
            }
            else if ((ev.Pickup.Position - Config.NTFSlotPos).magnitude < Config.pickupRange) {
                ev.Pickup.Destroy();
                result = -1;
                position = Config.NTFSlotPos;
                rotation = Quaternion.AngleAxis(PluginCore.NTFSlots.Body[0].Rotation.y, Vector3.up) * Vector3.forward;
                Timing.RunCoroutine(Gamble(PluginCore.NTFSlots, item, position, rotation));
            }
        }
        
        public IEnumerator<float> Gamble(SlotMachine sm, ItemType item ,Vector3 position, Vector3 rotation) {
            int[] indicies = [Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8)];
            
            int result = 0;
            if (indicies[0] == indicies[1] && indicies[0] == indicies[2]) if (indicies[0] == 0) {
                    result = 2;
                }
                else {
                    result = 1;
                }
            //wheels will spin for 4s 1s 1s and will stop at randomly generated index
            
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
}