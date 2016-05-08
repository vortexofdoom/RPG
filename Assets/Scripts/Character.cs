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
	
	private Stance[] stances; //wish we could use this array to drag Stance derived scripts into the inspector
	private int currentStance;


	//Not a stat but should probably declare it here
	private Ability[] activeAbilities;
	private int abilityIndex;


	//There is an argument to be made for incorporating this into the Stance class
	//If we did this I would just name it Activate() and take no arguments
	//Also a candidate for being broken out into future Controller class
	//I'd probably keep this and split off SwitchStance() instead [Vortex]
	public void ActivateStance(Stance someStance)
	{
		str = someStance.Str();
		agi = someStance.Agi();
		pwr = someStance.Pwr();
		Debug.Log("Current Stance: " + stances[currentStance]);
		Debug.Log("Str: " + str + " Agi: " + agi + " Pwr: " + pwr);
	}

	/// <summary>
	/// <para>Switches the character's stance</para>
	/// </summary>
	/// <param name="next">true for next stance, false for previous stance (default true)</param>
	public void SwitchStance(bool next = true)	//Definitely a candidate for a split off into Controller class [Vortex]
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

	//I was thinking that many of these things could be broken out into other scripts this way
	//Define it in a non-monobehaviour class and include it that way.
	//Lets one script add multiple menus, pretty nice
	public Inventory inventory;

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
		// Stops the velocity being dependent on framerate
		newVelocity *= Time.deltaTime;
		velocity += newVelocity;
	}

	#endregion

	#region Ability-related Character-executable Functions from AbilityHotbar.cs [Lolop/Nostro?]
	//The remainder of the code from that script will likely be incorporated into Input and UI classes if it is used at all

	/// <summary>
	/// Uses the ability. This is usually activated by clicking the hotbar button or by a keybinding
	/// Errors (null's) are caught here.
	/// </summary>
	/// <param name="abilityIndex"></param>
	public void UseAbility(int abilityIndex)
	{
		// Check that the active abilities are not null;
		if (activeAbilities == null)
		{
			Debug.LogError("Ability Array is null. Something didn't initialize");
			return;
		}

		// Check there is an ability. If there is no ability exit 
		if (activeAbilities[abilityIndex] == null)
		{
			Debug.LogError("No ability present at index " + abilityIndex);
			return;
		}

		// This is a method implimented by the ability class. 
		//Each class will have a different implimentation
		activeAbilities[abilityIndex].UseAbility();
	}

	#endregion

	private void Awake()
	{
		//Initialize this here but do not set its values
		//Make sure Ability.cs does what it needs to in the awake function
		activeAbilities = new Ability[4];
	}

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		velocity = Vector2.zero;
		anim = GetComponent<Animator>();
		stances = GetComponents<Stance>();
		currentStance = 0;
		ActivateStance(stances[currentStance]);
	}

	private void Update()
	{
		
	}

	private void FixedUpdate()  //only contains Movement code atm
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