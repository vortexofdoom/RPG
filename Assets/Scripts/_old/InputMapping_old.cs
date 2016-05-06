using UnityEngine;
using System.Collections.Generic;

public class InputMapping : MonoBehaviour {

    private Character character;
    [SerializeField]
    private AbilityHotbar abilityHotbar;

    private void Start()
    {
        if (character == null) {
            Debug.LogAssertion("Forgot to add movement component in unity inspector");
        }

        if (abilityHotbar == null) {
            Debug.LogAssertion("Forgot to add abilityHotbar in unity inspector");
        }

		character = GetComponent<Character>();
	}

    private void Update()
    {
        UpdateVelocity();
        UpdateAttacks();
    }

    private void UpdateAttacks()
    {
        if (Input.GetMouseButtonDown(0)) {
            abilityHotbar.UseAbility(0);
        }
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

        character.AddVelocity(velocity);

    }
}