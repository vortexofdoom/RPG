using UnityEngine;
using System.Collections.Generic;

namespace RPG 
{
    /// <summary>
    /// Script used to test functionality. Mostly as a debug tool.
    /// E.g Add specific abilities to the character at start.
    /// </summary>
    public class TestScript : MonoBehaviour {
    
        void Start () {
            // Get The ability component
            var abilityComponent = GetComponent<AbilityHotbar>();

            // Add some dummy abilities to it. (They do nothing yet)
            abilityComponent.SetAbility(0, new Slash());    
        }

        void Update()
        {
            // Quick test to make sure the health gets updated properly.
            if (Time.time % 4 < 2) {
                GetComponent<Player>().DealDamage(0.2f);
            } else {
                GetComponent<Player>().Heal(0.2f);
            }
        }
        
    }
}