using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG 
{
    public class FireStance : Stance
    {
        public FireStance()
        {
            StanceName = "Fire";
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