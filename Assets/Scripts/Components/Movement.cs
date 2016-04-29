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

            // Resets the velocity
            velocity = new Vector2();

            // Sets the 'MoveVelX' and 'MoveVelY' Animator Parameters 
            anim.SetFloat("MoveVelX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveVelY", Input.GetAxisRaw("Vertical"));
        }
    }
}
