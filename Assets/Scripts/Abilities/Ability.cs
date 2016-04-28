using UnityEngine;
using System.Collections.Generic;

namespace RPG 
{
    /// <summary>
    /// Abstract base class for all abilities.
    /// Sets up the basic functions required for an ability to operate.
    /// </summary>
    public abstract class Ability {

        public string AbilityName { get; protected set; }

        // will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
        protected static Sprite abilityIcon;
        public Sprite AbilityIcon { get { return abilityIcon; } }
        
        public abstract void UseAbility();
    }
}