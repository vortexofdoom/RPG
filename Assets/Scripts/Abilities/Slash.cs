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

            if (abilityIcon == null)
                abilityIcon = Resources.Load<Sprite>(iconPath);
        }

        /// <summary>
        /// Activates this ability. Causing the player to slash in front of them. 
        /// </summary>
        public override void UseAbility()
        {
            Debug.Log("You slash at the enemy -- Not implimented yet");
        }
    }
}