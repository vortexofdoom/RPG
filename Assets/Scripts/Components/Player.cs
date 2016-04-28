/*
    A class for holding player's variables, and doing player related functions?
                                Nostro Vostro(Trevor)
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace RPG
{
    public class Player : MonoBehaviour
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
                UpdateHealthUI();
            }
        }
        
        private float HealthPercentage { get { return CurrentHealth / maxHealth; } }

        /*******************  Private variables  *******************/

        [SerializeField]
        private Movement movementComponent;

        [SerializeField]
        private string playerName = "";

        [SerializeField] [HideInInspector]
        private float currentHealth;

        [SerializeField]
        private float maxHealth;

        [SerializeField]
        private Slider healthBar; // Healthbar slider

        /*******************  Unity Methods  *******************/

        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            UpdateVelocity();
        }

        /*******************  Public Methods  *******************/

        /// <summary>
        /// Deals damage to the player by the specified amount
        /// </summary>
        /// <param name="damageAmount">Amount of damage to deal</param>
        public void DealDamage(float damageAmount)
        {
            CurrentHealth -= damageAmount;
        }

        /// <summary>
        /// Healths the player by the specified amount. 
        /// Cannot go above the max health.
        /// </summary>
        /// <param name="healAmount">Amount to heal by</param>
        public void Heal(float healAmount)
        {
            CurrentHealth += healAmount;
        }

        /*******************  Private Methods  *******************/

        /// <summary>
        /// This will only need to be called when the player is damaged. 
        /// </summary>
        private void UpdateHealthUI()
        {
            // Changes the Health bars X value to be the same as the percentage health. 
            // E.g At 50% health it will be half as long. At 0% health it will not be visible.

            //healthBar.transform.localScale = new Vector3(HealthPercentage, 1);

            //Sets the healthbar slider value to be current health
            healthBar.value = currentHealth;
        }

        /// <summary>
        /// Updates the players velocity based on inputs.
        /// </summary>
        private void UpdateVelocity()
        {
            var velocity = new Vector2();

            // Will probably consider using ".GetAxisRaw" instead? This has a smoothing effect
            // Which means you don't stop straight away
            velocity.x = Input.GetAxis("Horizontal");
            velocity.y = Input.GetAxis("Vertical");

            // Stops the velocity being dependent on framerate
            velocity *= Time.deltaTime;

            movementComponent.AddVelocity(velocity);

        }
    }
}
