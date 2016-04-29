using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace RPG 
{
    /// <summary>
    /// Singleton class containing basic interaction functions with the UI. 
    /// If any changes are to be done to the UI, it must be through a function in this
    /// Class. To use this write "UIManager.Inst.FUNCTION_NAME"
    /// </summary>
    public class UIManager : MonoBehaviour {
    
        public static UIManager Inst { get; protected set; }

        [SerializeField]
        private Slider healthBar;
        
        [SerializeField]
        private Button[] abilityButtons;
        private Image[] abilityImages;

        [SerializeField]
        private Image leftStanceImage;
        [SerializeField]
        private Image rightStanceImage;
        [SerializeField]
        private Image activeStanceImage;


        private void Awake()
        {
            // Creates the singleton item if it hasn't already been made.
            if (Inst == null)
                Inst = this;
        }

        public void UpdateHealthBarValue(float percentage)
        {
            // This will probably have to be changed?
            healthBar.value = percentage;
        }

        public void SetAbilityIcon(int index, Sprite newSprite)
        {
            abilityButtons[index].GetComponent<Image>().sprite = newSprite;
        }

        public void SetAbilityState(int index, bool interactable)
        {
            abilityButtons[index].interactable = interactable;
        }

        public void SetLeftStance(Sprite newStanceIcon)
        {
            leftStanceImage.sprite = newStanceIcon;
        }

        public void SetRightStance(Sprite newStanceIcon)
        {
            rightStanceImage.sprite = newStanceIcon;
        }

        public void SetActiveStance(Sprite newStanceIcon)
        {
            activeStanceImage.sprite = newStanceIcon;
        }
    }
}