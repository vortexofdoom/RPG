using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an ability to operate.
/// </summary>
public abstract class Ability {

	private Character character;	//For accessing the character and their stats
	private GameObject weapon;      //For accessing the weapon and its stats
	///<summary>
	///This damage variable is common to all offensive abilities
	///<para>The variable should probably only be changed in the AbilityImplementation</para>
	///</summary>
	private float damage = 0f;		//Should maybe use public if we use it to have a base attack value
	
	/// <summary>
	/// Called when an ability is used. The string represents ohshit deleted
	/// </summary>
	private Action<string> onAbilityUsed;

	public string AbilityName { get; set; }

	// will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
	public Sprite AbilityIcon { get; set; }

	/// <summary>
	/// This is the function to override for the functionality of the ability (This is where all the logic goes)
	/// Will probably be renamed
	/// </summary>
	protected abstract void AbilityImplementation();

	public void UseAbility()
	{
		AbilityImplementation();

		if (onAbilityUsed == null)
			return;

		onAbilityUsed(AbilityName);
	}
}
