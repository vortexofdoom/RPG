using UnityEngine;
using System.Collections.Generic;

namespace RPG 
{
    /// <summary>
    /// Abstract base class for all abilities.
    /// Sets up the basic functions required for an Stance to operate.
    /// </summary>
    public class Stance 
    {

        public string StanceName { get; protected set; }

        // will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
        protected static Sprite stanceIcon;
        public Sprite StanceIcon { get { return stanceIcon; } }

        public virtual void ActivateStance() { }
        public virtual void DeactivateStance() { }
    }
}