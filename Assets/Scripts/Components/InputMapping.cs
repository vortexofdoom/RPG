using UnityEngine;
using System.Collections.Generic;

namespace RPG 
{
	public class InputMapping : MonoBehaviour {
		
		[SerializeField]
		private Movement movementComponent;

		private void Start()
		{
			if (movementComponent == null) {
				Debug.LogAssertion("Forgot to add movement component in unity inspector");
				movementComponent = GetComponent<Movement>();
			}
		}

		private void Update()
		{
			UpdateVelocity();
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