//using UnityEngine;
//using System.Collections.Generic;
//using System;


//public abstract class Ability_old
//{

//	/// <summary>
//	/// Called when an ability is used. The string represents 
//	/// </summary>
//	private Action<string> onAbilityUsed;

//	public string AbilityName { get; set; }

//	// will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
//	public Sprite AbilityIcon { get; set; }

//	/// <summary>
//	/// This is the function to override for the functionality of the ability (This is where all the logic goes)
//	/// Will probably be renamed
//	/// </summary>
//	protected abstract void AbilityImplementation();

//	public void UseAbility()
//	{
//		AbilityImplementation();

//		if (onAbilityUsed == null)
//			return;

//		onAbilityUsed(AbilityName);
//	}
//}