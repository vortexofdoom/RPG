using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RPG 
{
	public class PlayerUI : MonoBehaviour {

		[SerializeField]
		private Stats playerStats;

		[SerializeField]
		private AbilityHotbar abilityHotbar;

		[SerializeField]
		private StanceBar stanceBar;


		/// <summary>
		/// Used to set up the callbacks for the player UI system.
		/// </summary>
		private void Start()
		{
			playerStats.RegisterOnHealthModifiedCallback(UIManager.Inst.UpdateHealthBarValue);
			
			stanceBar.RegisterOnStanceChangeCallback(OnStanceChange);
		}

		private void OnStanceChange(Stance activeStance, Stance leftStance, Stance rightStance)
		{
			UIManager.Inst.SetActiveStance(activeStance.StanceIcon);
			UIManager.Inst.SetLeftStance(leftStance.StanceIcon);
			UIManager.Inst.SetRightStance(rightStance.StanceIcon);
		}
	}
}