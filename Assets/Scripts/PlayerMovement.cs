/*
    Uses basic Up, down, left, and right movement.
    Movement is based off Horizontal, and Vertical Axis
  
        NostroVostro (Trevor LeCroy)
*/
using UnityEngine;
using System.Collections;

namespace RPG.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField]
        float speed = 3f;

        // Used so that Update can listen for input, and FixedUpdate can move the player 
        float xMove;
        float yMove;

        Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            xMove = Input.GetAxis("Horizontal") * speed;
            yMove = Input.GetAxis("Vertical") * speed;
        }

        void FixedUpdate()
        {
            rb.velocity = new Vector2(xMove, yMove);
        }
    }
}