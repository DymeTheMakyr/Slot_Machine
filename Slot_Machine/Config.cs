

using Exiled.API.Interfaces;
using PluginAPI.Core;
using UnityEngine;

namespace Slot_Machine {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
        
        
        public static Vector3 NTFSlotPos = new Vector3(131.5f, 995.8f, -30.75f);
        public static Vector3 CISlotPos = new Vector3(7.5f, 991.8f, -35f);

        public static float pickupRange = 2f;

        public static Color red = new (0.878f, 0.031f, 0.043f,1f);
        public static Color yellow = new (0.853f, 0.676f, 0.025f, 1f);
        public static Color green = new (0.004f, 0.427f, 0.161f, 1f);
        public static Color pink = new (1f, 0.412f, 0.706f, 1f);
        public static Color warmWhite = new(1f, 0.976f, 0.847f, 1f);
    }
}