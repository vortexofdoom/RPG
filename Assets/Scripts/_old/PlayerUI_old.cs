//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;

//public class PlayerUI : MonoBehaviour
//{

//	private Character character;

//	[SerializeField]
//	private Stats playerStats;

//	[SerializeField]
//	private AbilityHotbar abilityHotbar;

//	[SerializeField]
//	private StanceBar stanceBar;

//	/// <summary>
//	/// Used to set up the callbacks for the player UI system.
//	/// </summary>
//	private void Awake()
//	{
//		playerStats.RegisterOnHealthModifiedCallback(OnHealthModified);

//		abilityHotbar.RegisterOnAbilityChangedCallback(OnAbilityChanged);

//		stanceBar.RegisterOnStanceChangeCallback(OnStanceChange);
//	}

//	private void OnHealthModified(float newHealth)
//	{
//		UIManager.Inst.UpdateHealthBarValue(newHealth);
//	}

//	private void OnAbilityChanged(int index, Ability newAbility)
//	{
//		if (newAbility == null)
//		{
//			UIManager.Inst.SetAbilityIcon(index, null);
//			UIManager.Inst.SetAbilityState(index, false);
//			return;
//		}

//		UIManager.Inst.SetAbilityIcon(index, newAbility.AbilityIcon);
//		UIManager.Inst.SetAbilityState(index, true);
//	}

//	private void OnStanceChange(Stance activeStance, Stance leftStance, Stance rightStance)
//	{
//		UIManager.Inst.SetActiveStance(activeStance.StanceIcon);
//		UIManager.Inst.SetLeftStance(leftStance.StanceIcon);
//		UIManager.Inst.SetRightStance(rightStance.StanceIcon);
//	}
//}