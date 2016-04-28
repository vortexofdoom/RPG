using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RPG 
{
    public class AbilityHotbar : MonoBehaviour {
        [SerializeField]
        private int maxNumOfAbilities;

        [SerializeField]
        private Ability[] activeAbilities;

        [SerializeField]
        private GameObject[] abilityButtons;

        private void Awake()
        {
            activeAbilities = new Ability[maxNumOfAbilities];
        }

        /// <summary>
        /// Uses the ability. This is usually activated by clicking the hotbar button or by a keybinding
        /// Errors (null's) are caught here.
        /// </summary>
        /// <param name="abilityIndex"></param>
        public void UseAbility(int abilityIndex)
        {
            // Check that the active abilities are not null;
            if (activeAbilities == null) {
                Debug.LogError("Ability Array is null. Something didn't initialize");
                return;
            }

            // Check there is an ability. If there is no ability exit 
            if (activeAbilities[abilityIndex] == null) {
                Debug.LogError("No ability present at index " + abilityIndex);
                return;
            }

            // This is a method implimented by the ability class. 
            //Each class will have a different implimentation
            activeAbilities[abilityIndex].UseAbility();
        }

        /// <summary>
        /// Adds/overrides an ability to the hotbar
        /// </summary>
        /// <param name="index">The index of the new ability</param>
        /// <param name="newAbility">New ability to add</param>
        public void SetAbility(int index, Ability newAbility)
        {
            // We don't want to set the ability to null. There will be a separate method to remove abilities 
            if (newAbility == null) {
                Debug.LogError("New Ability being added is null (Index " + index + ")");
                abilityButtons[index].GetComponent<Button>().interactable = false;
                return;
            }

            activeAbilities[index] = newAbility;
            
            abilityButtons[index].GetComponent<Image>().sprite = newAbility.AbilityIcon;
            abilityButtons[index].GetComponent<Button>().interactable = true;

            //Change the text of the button so we know what ability is bound to that button (No longer needed)
            //abilityButtons[index].GetComponentInChildren<Text>().text = newAbility.AbilityName;
        }
        
    }
}