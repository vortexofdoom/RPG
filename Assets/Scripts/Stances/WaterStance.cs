using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG 
{
    public class WaterStance : Stance
    {
        private string iconPath = "Sprites/Water-Stance-Icon";

        public WaterStance()
        {
            StanceName = "Water";

            if (StanceIcon == null)
                StanceIcon = Resources.Load<Sprite>(iconPath);
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