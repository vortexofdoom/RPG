//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using System;

//public class AbilityHotbar : MonoBehaviour
//{

//	[SerializeField]
//	private Ability[] activeAbilities;

//	//Hasn't been reincorporated yet
//	private Action<int, Ability> onAbilityChanged;

//	private void Awake()
//	{
//		activeAbilities = new Ability[4];
//	}

//	/// <summary>
//	/// Uses the ability. This is usually activated by clicking the hotbar button or by a keybinding
//	/// Errors (null's) are caught here.
//	/// </summary>
//	/// <param name="abilityIndex"></param>
//	public void UseAbility(int abilityIndex)
//	{
//		// Check that the active abilities are not null;
//		if (activeAbilities == null)
//		{
//			Debug.LogError("Ability Array is null. Something didn't initialize");
//			return;
//		}

//		// Check there is an ability. If there is no ability exit 
//		if (activeAbilities[abilityIndex] == null)
//		{
//			Debug.LogError("No ability present at index " + abilityIndex);
//			return;
//		}

//		// This is a method implimented by the ability class. 
//		//Each class will have a different implimentation
//		activeAbilities[abilityIndex].UseAbility();
//	}


//	//	This is good functionality but should probably be called from a player-specific script
//	//	Not all Characters will need the ability to switch
//	//	If it's reincorporated we may want to change a bit
//	/// <summary>
//	/// Adds/overrides an ability to the hotbar
//	/// </summary> 
//	/// <param name="index">The index of the new ability</param>
//	/// <param name="newAbility">New ability to add</param>
//	public void SetAbility(int index, Ability newAbility)
//	{
//		// We don't want to set the ability to null. There will be a separate method to remove abilities 
//		if (newAbility == null)
//			Debug.LogError("New Ability being added is null (Index " + index + ")");

//		activeAbilities[index] = newAbility;

//		onAbilityChanged(index, newAbility);
//	}

//	public void RegisterOnAbilityChangedCallback(Action<int, Ability> callback)
//	{
//		onAbilityChanged += callback;
//	}
//}