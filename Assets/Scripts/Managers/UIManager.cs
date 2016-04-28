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
        private Image ActiveStanceImage;
        [SerializeField]
        private Image RightStanceImage;
        [SerializeField]
        private Image leftStanceImage;


        private void Awake()
        {
            // Creates the singleton item if it hasn't already been made.
            if (Inst == null)
                Inst = this;
        }

        public void UpdateHealthBarValue(float newVal)
        {
            // This will probably have to be changed?
            healthBar.value = newVal;
        }

        public void SetLeftStance(Sprite newStanceIcon)
        {
            leftStanceImage.sprite = newStanceIcon;
        }

        public void SetRightStance(Sprite newStanceIcon)
        {
            RightStanceImage.sprite = newStanceIcon;
        }

        public void SetActiveStance(Sprite newStanceIcon)
        {
            ActiveStanceImage.sprite = newStanceIcon;
        }
    }
}