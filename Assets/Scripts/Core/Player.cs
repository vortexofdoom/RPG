/*
    A class for holding player's variables, and doing player related functions?
                                Nostro Vostro(Trevor)
*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Movement movementComponent;

        [SerializeField]
        private string playerName = "";
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        [SerializeField]
        private float health;
        public float Health { get { return health; } }

        private void Update()
        {
            var velocity = new Vector2();

            velocity.x = Input.GetAxis("Horizontal");
            velocity.y = Input.GetAxis("Vertical");

            // Stops the velocity being dependent on framerate
            velocity *= Time.deltaTime;

            movementComponent.AddVelocity(velocity);
        }

    }
}
