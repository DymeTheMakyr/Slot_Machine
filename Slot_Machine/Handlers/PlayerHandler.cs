using Exiled.API.Features.Items;
using Exiled.API.Features.Toys;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;
using Light = Exiled.API.Features.Toys.Light;

namespace Slot_Machine.Handlers {
    public class PlayerHandler {
        private PluginCore Inst = PluginCore.Instance;
        
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
            ItemType item = ev.Pickup.Type;
            Vector3 position = Vector3.negativeInfinity;
            Vector3 rotation = Vector3.negativeInfinity;
            if ((ev.Pickup.Position - Config.CISlotPos).magnitude < 1f) {
                ev.Pickup.Destroy();
                position = Config.CISlotPos;
                rotation = Quaternion.AngleAxis(Inst.CISlots[0].Rotation.y, Vector3.up) * Vector3.forward;
            }
            else if ((ev.Pickup.Position - Config.NTFSlotPos).magnitude < 1f) {
                ev.Pickup.Destroy();
                position = Config.NTFSlotPos;
                rotation = Quaternion.AngleAxis(Inst.NTFSlots[0].Rotation.y, Vector3.up) * Vector3.forward;
            }
            if (position != Vector3.negativeInfinity && rotation != Vector3.negativeInfinity){
                int result = Gamble(Inst.CISlots, Inst.CILights);
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
                        Item.Create(tier[i + 1]).CreatePickup(position);
                    }
                    else {
                        Item.Create(tier[i]).CreatePickup(position);
                    }
                }
                else {
                    //play fail sound
                }
            }
        }

        public int Gamble(Primitive[] m, Light[] l) {
            int result = 0;
            
            //Needs MEC Do laters
            
            return result;
        }
    }
}