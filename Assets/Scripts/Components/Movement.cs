/*
    Uses basic Up, down, left, and right movement.
    Movement is based off Horizontal, and Vertical Axis
  
        NostroVostro (Trevor LeCroy)
*/
using UnityEngine;
using System.Collections.Generic;

namespace RPG
{
    public class Movement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3f;

        // Used so that Update can listen for input, and FixedUpdate can move the player.
        private Vector2 velocity;

        // Reference to the animator
        private Animator anim;

        Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        public void AddVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        void FixedUpdate()
        {

            // Normalizes the velocity so that you don't move faster when moving diagonally
            velocity.Normalize();

            rb.velocity = velocity * speed;

            // Sets the 'MoveVelX' and 'MoveVelY' Animator Parameters 
            // Made it based off the velocity, not the input as other factors
            // Can change the direction of the character. 
            anim.SetFloat("MoveVelX", velocity.x);
        
            anim.SetFloat("MoveVelY", velocity.y);
            // Stops him from trying to face up when he is already moving left/right
            if (velocity.x != 0)
                anim.SetFloat("MoveVelY", 0);


            // Resets the velocity
            velocity = new Vector2();
        }
    }
}
