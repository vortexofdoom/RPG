using UnityEngine;
using System.Collections.Generic;

namespace RPG 
{
    /// <summary>
    /// Abstract base class for all abilities.
    /// Sets up the basic functions required for an ability to operate.
    /// </summary>
    public abstract class Ability {

        private Sprite abilityIcon;
        public Sprite AbilityIcon { get { return abilityIcon; } }
        
        public abstract void UseAbility();
    }
}