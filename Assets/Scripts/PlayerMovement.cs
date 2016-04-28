/*
    Uses basic Up, down, left, and right movement.
    Movement is based off Horizontal, and Vertical Axis
  
        NostroVostro (Trevor LeCroy)
*/
using UnityEngine;
using System.Collections;

namespace RPG
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3f;

        // Used so that Update can listen for input, and FixedUpdate can move the player.
        private Vector2 velocity;

        Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            velocity.x += Input.GetAxis("Horizontal");
            velocity.y += Input.GetAxis("Vertical");

            // Stops the velocity being dependent on framerate
            velocity *= Time.deltaTime;
        }

        void FixedUpdate()
        {
            // Normalizes the velocity so that you don't move faster when moving diagonally
            velocity.Normalize();

            rb.velocity = velocity * speed;

            // Resets the velocity
            velocity = new Vector2();
        }
    }
}