using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

namespace RPG 
{
    public class StanceBar : MonoBehaviour {

        [SerializeField]
        private int maxNumOfStances;

        private Stance[] stances;

        private int activeStanceIndex;
        private Stance ActiveStance { get { return stances[activeStanceIndex]; } }
        private Stance LeftStance { get { return stances[Mathf.Abs((activeStanceIndex - 1) % maxNumOfStances)]; } }
        private Stance RightStance { get { return stances[Mathf.Abs((activeStanceIndex + 1) % maxNumOfStances)]; } }

        /// <summary>
        /// Stance order: Newly active stance, Stance to the left, Stance to the right (Look at UI)
        /// </summary>
        private Action<Stance, Stance, Stance> onStanceChange;

        private void Start()
        {
            stances = new Stance[maxNumOfStances];

            stances[0] = new FireStance();
            stances[1] = new WaterStance();

            activeStanceIndex = 0;

            if (onStanceChange == null)
                onStanceChange = (active, left, right) => { };

            SelectStance(1);
        }

        public void SelectStance(int newStanceIndex)
        {
            // Check if the stance is already active
            if (stances[newStanceIndex] == ActiveStance)
                return;

            ActiveStance.DeactivateStance();

            //Update active index
            activeStanceIndex = newStanceIndex;

            ActiveStance.ActivateStance();

            onStanceChange(ActiveStance, LeftStance, RightStance);
        }

        public void SelectNextStance()
        {
            SelectStance(Mathf.Abs((activeStanceIndex + 1) % maxNumOfStances));
        }
        
        public void SelectPrevStance()
        {
            SelectStance(Mathf.Abs((activeStanceIndex - 1) % maxNumOfStances));
        }

        /// <summary>
        /// Called when the state is altered (In the 'SelectStance' method)
        /// </summary>
        /// <param name="callback"></param>
        public void RegisterOnStanceChangeCallback(Action<Stance, Stance, Stance> callback)
        {
            onStanceChange += callback;
        }
    }
}