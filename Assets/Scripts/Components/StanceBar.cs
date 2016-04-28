using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RPG 
{
    public class StanceBar : MonoBehaviour {

        [SerializeField]
        private int maxNumOfStances;

        private Stance[] stances;

        private int activeStanceIndex;
        private Stance ActiveStance { get { return stances[activeStanceIndex]; } }

        [SerializeField]
        private GameObject ActiveStanceButton; // Temporary for now
        [SerializeField]
        private GameObject PrevStanceButton; // Temporary for now
        [SerializeField]
        private GameObject NextStanceButton; // Temporary for now

        private void Start()
        {
            stances = new Stance[maxNumOfStances];

            stances[0] = new FireStance();
            stances[1] = new WaterStance();

            activeStanceIndex = 0;

            UpdateUI();
        }

        public void SelectStance(int newStanceIndex)
        {
            // Check if the stance is already active
            if (stances[newStanceIndex] == ActiveStance)
                return;

            ActiveStance.DeactivateStance();

            activeStanceIndex = newStanceIndex;

            UpdateUI();
        }

        public void SelectNextStance()
        {
            SelectStance(Mathf.Abs((activeStanceIndex + 1) % maxNumOfStances));
        }
        
        public void SelectPrevStance()
        {
            SelectStance(Mathf.Abs((activeStanceIndex - 1) % maxNumOfStances));
        }

        private void UpdateUI()
        {
            // Update the active stance
            ActiveStance.ActivateStance();
            ActiveStanceButton.GetComponentInChildren<Text>().text = ActiveStance.StanceName;

            /* Note the mathf.abs and % operator just make it so it loops around instead of going out of range of the array.
               I will clean it up later, but for now this should work with any number of stances */

            // Update the previous stance
            PrevStanceButton.GetComponentInChildren<Text>().text = stances[Mathf.Abs((activeStanceIndex - 1) % maxNumOfStances)].StanceName;
            
            // Update the next stance
            NextStanceButton.GetComponentInChildren<Text>().text = stances[Mathf.Abs((activeStanceIndex + 1) % maxNumOfStances)].StanceName;
        }
    }
}