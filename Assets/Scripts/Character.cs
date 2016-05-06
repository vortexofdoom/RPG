using UnityEngine;
using System.Collections.Generic;
using RPG;

public class Character : MonoBehaviour {
	
	//Primal Stats
	private float primalStat1;
	private float primalStat2;

	//Base Stats that combat uses
	private float str;  //Strength	[Most physical abilities and things like HP]
	private float agi;  //Agility	[Select physical abilities and things like movement Speed]
	private float pwr;  //Power		[Most non-physical abilities]

	//one way to include stances in a character is hardcode them
	//using these for now	
	/// <summary>
	/// <para>TODO: Fix the use of the Stance class.</para>
	/// <para>Possible Fix 1: Figure out the AddComponent() function</para>
	/// <para>Possible Fix 2: Change Stance to a ScriptableObject</para>
	/// </summary>

	protected Stance[] stances; //wish we could use this array to drag Stance derived scripts into the inspector
	private int currentStance;

	void Start() {
		stances = GetComponents<Stance>();
		currentStance = 0;
		ActivateStance(stances[currentStance]);
	}

	//There is an argument to be made for incorporating this into the Stance class
	//If we did this I would just name it Activate() and take no arguments
	void ActivateStance(Stance someStance)
	{
		str = someStance.Str();
		agi = someStance.Agi();
		pwr = someStance.Pwr();
		Debug.Log("Current Stance: " + stances[currentStance]);
		Debug.Log("Str: " + str + " Agi: " + agi + " Pwr: " + pwr);
	}

	/// <summary>
	/// <para>Switches the stance.</para>
	/// true for next stance, false for previous stance
	/// </summary>
	void SwitchStance(bool next)
	{
		int max = stances.Length - 1; //just to clear up the array indexing confusion
		if (next) {
			if ( currentStance < max) {
				currentStance++;
			} else {
				currentStance = 0;
			}
		} else {
			if (currentStance > 0) {
				currentStance--;
			} else {
				currentStance = max;
			}
		}
		ActivateStance(stances[currentStance]);
	}

	///TODO: Fix this dumb implementation
	//public void Buff(float stat, float value, float durationInSeconds) {
	//	float startTime = Time.time;
	//	float startStat = stat;
	//	float buffedStat = stat + value;
	//	while (Time.time - startTime < durationInSeconds) {
	//		stat = buffedStat;
	//	}
	//	stat = startStat;
	//}

	void Update()
	{
		//checking if the input is asking for a stance change, here represented by a quick and dirty arrow key check
		//Need to plug input back in next
		//the idea of pulling it out of update directly is to set these character-bound variables once per stance change
		//then leave them until next time the stance changes, rather than calculating every frame
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			SwitchStance(true);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			SwitchStance(false);
		}
	}
}
