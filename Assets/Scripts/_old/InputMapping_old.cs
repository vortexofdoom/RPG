//using UnityEngine;
//using System.Collections.Generic;

//public class InputMapping_old : MonoBehaviour
//{

//	private Character character;
//	[SerializeField]
//	private AbilityHotbar abilityHotbar;

//	private void Start()
//	{
//		if (character == null)
//		{
//			Debug.LogAssertion("Forgot to add character component in unity inspector");
//		}

//		if (abilityHotbar == null)
//		{
//			Debug.LogAssertion("Forgot to add abilityHotbar in unity inspector");
//		}

//		character = GetComponent<Character>();
//	}

//	private void Update()
//	{
//		UpdateVelocity();
//		UpdateAttacks();
//	}

//	private void UpdateAttacks()
//	{
//		if (Input.GetMouseButtonDown(0))
//		{
//			abilityHotbar.UseAbility(0);
//		}
//	}

//	/// <summary>
//	/// Updates the players velocity based on inputs.
//	/// </summary>
//private void UpdateVelocity(Vector2 velocity)
//{
	//// Stops the velocity being dependent on framerate
	//velocity *= Time.deltaTime;

	//character.AddVelocity(velocity);
//}
//}