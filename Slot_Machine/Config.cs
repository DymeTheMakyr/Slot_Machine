

using Exiled.API.Interfaces;
using UnityEngine;

namespace Slot_Machine {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        public Vector3 NTFSlotPos = new Vector3(131.5f, 996f, 31f);
        public Vector3 CISlotPos = new Vector3(7.5f, 992f, -35f);
    }
}