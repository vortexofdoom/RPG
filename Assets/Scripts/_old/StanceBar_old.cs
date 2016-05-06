//using UnityEngine;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using System;

//public class StanceBar : MonoBehaviour
//{

//	private int numOfStances { get { return stances.Length; } }

//	private Stance[] stances;

//	private int activeStanceIndex;
//	private Stance ActiveStance { get { return stances[activeStanceIndex]; } }
//	private Stance LeftStance { get { return stances[Mathf.Abs((activeStanceIndex - 1) % numOfStances)]; } }
//	private Stance RightStance { get { return stances[Mathf.Abs((activeStanceIndex + 1) % numOfStances)]; } }

//	/// <summary>
//	/// Stance order: Newly active stance, Stance to the left, Stance to the right (Look at UI)
//	/// </summary>
//	private Action<Stance, Stance, Stance> onStanceChange;

//	private void Start()
//	{
//		stances = new Stance[2];

//		stances[0] = new FireStance();
//		stances[1] = new WaterStance();

//		activeStanceIndex = 0;

//		if (onStanceChange == null)
//			onStanceChange = (active, left, right) => { };

//		SelectStance(1);
//	}

//	public void SelectStance(int newStanceIndex)
//	{
//		// Check if the stance is already active
//		if (stances[newStanceIndex] == ActiveStance)
//			return;

//		ActiveStance.DeactivateStance();

//		//Update active index
//		activeStanceIndex = newStanceIndex;

//		ActiveStance.ActivateStance();

//		onStanceChange(ActiveStance, LeftStance, RightStance);
//	}

//	public void SelectNextStance()
//	{
//		SelectStance(Mathf.Abs((activeStanceIndex + 1) % numOfStances));
//	}

//	public void SelectPrevStance()
//	{
//		SelectStance(Mathf.Abs((activeStanceIndex - 1) % numOfStances));
//	}

//	/// <summary>
//	/// Called when the state is altered (In the 'SelectStance' method)
//	/// </summary>
//	/// <param name="callback"></param>
//	public void RegisterOnStanceChangeCallback(Action<Stance, Stance, Stance> callback)
//	{
//		onStanceChange += callback;
//	}
//}