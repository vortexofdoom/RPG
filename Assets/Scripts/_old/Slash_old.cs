using UnityEngine;
using System.Collections.Generic;
using System;

public class Slash : Ability
{
	private string iconPath = "Sprites/Slash-Ability-Icon";
	private int attackReach = 2;
	private int maxTargets = 5;

	private Transform charTransform;

	private Vector2 CharPosition { get { return charTransform.position + new Vector3(0.5f, 0); } }
	private Vector2 TargetPosition
	{
		get
		{
			// Gets the mouse position relative to the world
			var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

			// Find the direction of the mouse from the character by finding the difference.
			// Then normalize it (So it has a length of 1), multiply it by the reach of the attack.
			// Then offset it to the side of the mouse (The char position goes the opposite direction).
			return ((mousePos - CharPosition).normalized * 2) + new Vector2(-0.5f, 0);
		}
	}

	private Collider2D[] attackHits;

	public Slash(Transform transform)
	{
		AbilityName = "Slash";

		attackHits = new Collider2D[maxTargets];

		charTransform = transform;

		if (AbilityIcon == null)
			AbilityIcon = Resources.Load<Sprite>(iconPath);
	}

	/// <summary>
	/// Actual logic for the ability goes here. This is where the collision stuff goes.
	/// </summary>
	protected override void AbilityImplementation()
	{
		// This will be changed so the that CharPosition actually corrisponds to a circle around him. This will
		// Make the attacks more accurate. Atm it is creating a rectangle from the player to the target location. 

		// Using the 'nonAlloc' version will be better for performance as there is no garbage created.
		// To ignore the player we have to ignore the players layer. This means hit everything except layer 8 (Player layer)
		// Read up on bit masks if you don't understand bit shifting and how the layers work in unity.
		Debug.Log(Physics2D.OverlapAreaNonAlloc(CharPosition, TargetPosition, attackHits, ~(1 << 8)));
	}
}