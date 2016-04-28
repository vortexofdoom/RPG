/*
    A class for holding player's variables, and doing player related functions?
                                Nostro Vostro(Trevor)
*/
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

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
            set {
                // Stops health going above max health, and below 0
                currentHealth = Mathf.Clamp(value, 0, maxHealth);
                OnHealthModified(currentHealth);
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

        /*******************  Callbacks *******************/

        /// <summary>
        /// Callback for when the damage is taken.
        /// The int parameter refers to the AMOUNT of damage taken
        /// Note: More parameters can be added, such as the source, etc
        /// </summary>
        private Action<float> OnTakeDamage;

        /// <summary>
        /// Callback for when healing is recieved
        /// The int parameter refers to the AMOUNT of healing recieved
        /// </summary>
        private Action<float> OnRecieveHeal;

        /// <summary>
        /// Callback for when health has been modified in any way. This includes 
        /// the value being set. The float parameter represents the ACTUAL value of the health
        /// </summary>
        private Action<float> OnHealthModified;

        /*******************  Unity Methods  *******************/

        private void Start()
        {
            CurrentHealth = maxHealth;

            // Makes it so all the callbacks have an empty function. This will
            // Stop them returning null and crashing if they are empty.
            // If you dont understand this, **learn about Lambdas and delegates.**

            if (OnRecieveHeal == null)
                OnRecieveHeal = (x) => { };

            if (OnTakeDamage == null)
                OnTakeDamage = (x) => { };

            if (OnHealthModified == null)
                OnHealthModified = (x) => { };
        }

        /*******************  Public Methods  *******************/

        /// <summary>
        /// Deals damage to the player by the specified amount
        /// </summary>
        /// <param name="damageAmount">Amount of damage to deal</param>
        public void DealDamage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
            OnTakeDamage(damageAmount);
        }

        /// <summary>
        /// Healths the player by the specified amount. 
        /// Cannot go above the max health.
        /// </summary>
        /// <param name="healAmount">Amount to heal by</param>
        public void Heal(float healAmount)
        {
            CurrentHealth += healAmount;
            OnRecieveHeal(healAmount);
        }

        // TODO: Add comments for the callback registering functions
        public void RegisterOnHealthModifiedCallback(Action<float> callback)
        {
            OnHealthModified += callback;
        }

        public void RegisterOnDamageTakenCallback(Action<float> callback)
        {
            OnTakeDamage += callback;
        }

        public void RegisterOnHealRecievedCallback(Action<float> callback)
        {
            OnRecieveHeal += callback;
        }

        /*******************  Private Methods  *******************/

    }
}
