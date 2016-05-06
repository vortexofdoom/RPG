using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Character : MonoBehaviour {
	
	
	#region Stats and Stat-related functions [Vortex]
	//Primal Stats
	private float primalStat1;
	private float primalStat2;

	//Base Stats that combat uses
	private float str;  //Strength	[Most physical abilities and things like HP]
	private float agi;  //Agility	[Select physical abilities and things like movement Speed]
	private float pwr;  //Power		[Most non-physical abilities]

	[SerializeField]
	private Stance[] stances; //wish we could use this array to drag Stance derived scripts into the inspector
	private int currentStance;

	//There is an argument to be made for incorporating this into the Stance class
	//If we did this I would just name it Activate() and take no arguments
	//Also a candidate for being broken out into future Controller class
	//I'd probably keep this and split off SwitchStance() instead [Vortex]
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
	/// true for next stance, false for previous stance (default true)
	/// </summary>
	void SwitchStance(bool next = true)	//Definitely a candidate for a split off into Controller class [Vortex]
	{
		int max = stances.Length - 1;	//just to clear up the array indexing confusion
		if (next) {
			if ( currentStance < max) {
				currentStance++;
			}
			else {
				currentStance = 0;
			}
		}
		else {
			if (currentStance > 0) {
				currentStance--;
			}
			else {
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

	#endregion

	#region Inventory-related Code [Vortex]

	[SerializeField]
	private Inventory inventory;

	#endregion

	#region Movement-related Code from Movement.cs [NostroVostro + Lolop] 
	[SerializeField]
	private float speed = 3f;

	// Used so that Update can listen for input, and FixedUpdate can move the player.
	private Vector2 velocity;

	// Reference to the animator
	private Animator anim;

	Rigidbody2D rigidBody;

	public void AddVelocity(Vector2 newVelocity)
	{
		velocity += newVelocity;
	}

	#endregion

	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		stances = GetComponents<Stance>();
		currentStance = 0;
		ActivateStance(stances[currentStance]);
	}

	void Update()
	{
		//checking if the input is asking for a stance change, here represented by a quick and dirty arrow key check
		//Need to plug input back in
		//the idea of pulling it out of update directly is to set these character-bound variables once per stance change
		//then leave them until next time the stance changes, rather than calculating every frame
		if (Input.GetKeyDown(KeyCode.E))
		{
			SwitchStance(true);
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			SwitchStance(false);
		}
	}

	void FixedUpdate()  //only contains Movement code atm
	{

		// Normalizes the velocity so that you don't move faster when moving diagonally
		velocity.Normalize();

		rigidBody.velocity = velocity * speed;

		// Sets the 'MoveVelX' and 'MoveVelY' Animator Parameters 
		// Made it based off the velocity, not the input as other factors
		// Can change the direction of the character. 
		anim.SetFloat("MoveVelX", velocity.x);

		anim.SetFloat("MoveVelY", velocity.y);
		// Stops him from trying to face up when he is already moving left/right
		if (velocity.x != 0)
			anim.SetFloat("MoveVelY", 0);


		// Resets the velocity
		velocity = new Vector2();
	}
}