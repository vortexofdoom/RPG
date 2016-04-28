using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG 
{
    public class FireStance : Stance
    {
        private string iconPath = "Sprites/Fire-Stance-Icon";

        public FireStance()
        {
            StanceName = "Fire";
            
            if (StanceIcon == null)
                StanceIcon = Resources.Load<Sprite>(iconPath);
        }

        public override void ActivateStance()
        {
            Debug.Log("Activating Fire Stance");
        }

        public override void DeactivateStance()
        {
            Debug.Log("Deactivating Fire Stance");
        }
    }
}