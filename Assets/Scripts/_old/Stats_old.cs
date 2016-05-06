/*
    A class for holding player's variables, and doing player related functions?
                                Nostro Vostro(Trevor)
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace RPG
{
    /// <summary>
    /// 
    /// </summary>
    public class Stats : MonoBehaviour
    {

        /*******************  Public Properties  *******************/

        public string PlayerName {
            get { return playerName; }
            set { playerName = value; }
        }

        public float CurrentHealth {
            get { return currentHealth; }
            protected set {
                // Stops health going above max health, and below 0
                currentHealth = Mathf.Clamp(value, 0, maxHealth);

                if (onHealthModified == null)
                    return;

                onHealthModified(currentHealth);
            }
        }
        
        private float HealthPercentage { get { return CurrentHealth / maxHealth; } }

        /*******************  Private variables  *******************/

        [SerializeField]
        private string playerName = "";

        [SerializeField] [HideInInspector]
        private float currentHealth;

        [SerializeField]
        private float maxHealth;

        [SerializeField]
        private float baseStrength;

        [SerializeField]
        private float baseAgility;

        /*******************  Callbacks *******************/

        /// <summary>
        /// Callback for when the damage is taken.
        /// The int parameter refers to the AMOUNT of damage taken
        /// Note: More parameters can be added, such as the source, etc
        /// </summary>
        private Action<float> onTakeDamage;

        /// <summary>
        /// Callback for when healing is recieved
        /// The int parameter refers to the AMOUNT of healing recieved
        /// </summary>
        private Action<float> onRecieveHeal;

        /// <summary>
        /// Callback for when health has been modified in any way. This includes 
        /// the value being set. The float parameter represents the ACTUAL value of the health
        /// </summary>
        private Action<float> onHealthModified;
        
        /*******************  Unity Methods  *******************/

        private void Start()
        {
            CurrentHealth = maxHealth;
        }

        /*******************  Public Methods  *******************/

        /// <summary>
        /// Deals damage to the player by the specified amount
        /// </summary>
        /// <param name="damageAmount">Amount of damage to deal</param>
        public void DealDamage(float damageAmount)
        {
            CurrentHealth -= damageAmount;

            if (onTakeDamage == null)
                return;

            onTakeDamage(damageAmount);
        }

        /// <summary>
        /// Healths the player by the specified amount. 
        /// Cannot go above the max health.
        /// </summary>
        /// <param name="healAmount">Amount to heal by</param>
        public void Heal(float healAmount)
        {
            CurrentHealth += healAmount;

            if (onRecieveHeal == null)
                return;

            onRecieveHeal(healAmount);
        }

        /// <summary>
        /// Registers a listener for when the players health is set to a new value.
        /// This will still be called even if the health doesn't change (Already at 0 or full health)
        /// </summary>
        /// <param name="callback">Function template. The float param is the total current health</param>
        public void RegisterOnHealthModifiedCallback(Action<float> callback)
        {
            onHealthModified += callback;
        }

        /// <summary>
        /// Registers a listener for when the player recieves damage
        /// This will still be called even if the health doesn't change (Damage is 0)
        /// </summary>
        /// <param name="callback">Function template. The float param is the total current health</param>
        public void RegisterOnDamageTakenCallback(Action<float> callback)
        {
            onTakeDamage += callback;
        }

        /// <summary>
        /// Registers a listener for when the players gets a heal
        /// This will still be called even if the health doesn't change (Recieves a heal of 0 or at full health)
        /// </summary>
        /// <param name="callback">Function template. The float param is the total current health</param>
        public void RegisterOnHealRecievedCallback(Action<float> callback)
        {
            onRecieveHeal += callback;
        }

        /*******************  Private Methods  *******************/

    }
}
