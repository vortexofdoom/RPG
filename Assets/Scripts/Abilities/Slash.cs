using UnityEngine;
using System.Collections.Generic;
using System;

namespace RPG 
{
    public class Slash : Ability
    {
        private string iconPath = "Sprites/Slash-Ability-Icon";

        public Slash()
        {
            AbilityName = "Slash";

            if (AbilityIcon == null)
                AbilityIcon = Resources.Load<Sprite>(iconPath);
        }

        /// <summary>
        /// Actual logic for the ability goes here. This is where the collision stuff goes.
        /// </summary>
        protected override void AbilityImplementation()
        {
            Debug.Log("You slash at the enemy -- Not implimented yet");
        }
    }
}