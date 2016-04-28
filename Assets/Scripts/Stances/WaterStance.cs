using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG 
{
    public class WaterStance : Stance
    {
        public WaterStance()
        {
            StanceName = "Water";
        }

        public override void ActivateStance()
        {
            Debug.Log("Activating Water Stance");
        }

        public override void DeactivateStance()
        {
            Debug.Log("Deactivating Water Stance");
        }
    }
}