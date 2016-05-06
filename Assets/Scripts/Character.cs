using UnityEngine;
using System.Collections;
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
	private Stance fireStance;
	private Stance waterStance;
	private Stance earthStance;

	private Stance[] stances;       //wish we could use this array to drag Stance derived scripts into the inspector
	private Stance currentStance;   //Variable to assign your current stance to and call functions from

	void Start() {
		stances = new Stance[] { fireStance, waterStance, earthStance };
		currentStance = stances[0];
	}

	//There is an argument to be made for incorporating this into the Stance class
	//If we did this I would just name it Activate() and take no arguments
	void ActivateStance(Stance someStance)
	{
		str = someStance.Str();
		agi = someStance.Agi();
		pwr = someStance.Pwr();
		Debug.Log(someStance + " currently active");
	}

	void SwitchStance()
	{
		int max = stances.Length;
		for (int i = 0; i < max - 1; i++)
		{
			if (i != max)
			{
				currentStance = stances[i + 1];
			}
			else {
				currentStance = stances[0];
			}
			Debug.Log("Current Stance: " + currentStance);
			ActivateStance(currentStance);
		}
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
		//checking if the input is asking for a stance change, here represented by a quick and dirty spacebar check
		//Need to plug input back in next
		//the idea of pulling it out of update directly is to set these character-bound variables once per stance change
		//then leave them until next time the stance changes, rather than calculating every frame
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SwitchStance();
		}
	}
}
