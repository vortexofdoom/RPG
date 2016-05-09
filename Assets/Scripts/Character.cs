using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Character : MonoBehaviour {

	[SerializeField]
	private float speed = 3f;

	public bool canWalk = true; //variable that we'd make false if using knockback or during a cutscene perhaps
	private bool isWalking;     //Self-explanatory
	private Vector2 velocity;   //The sum total velocity acting on the player, incorporating things like wind or knockback
	private Vector2 walkVector; //The direction that the character is walking (if possible)

	// Reference to the animator
	private Animator anim;

	Rigidbody2D rigidBody;

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

	/// <summary>
	/// Sets velocity to the specified move vector.
	/// </summary>
	/// <param name="inputVector">The move vector.</param>
	public void Walk(Vector2 inputVector){
		if (canWalk)
		{
			isWalking = true;
			//	Sets the 'MoveDirX' and 'MoveDirY' Animator Parameters 
			//	Made it based off the velocity, not the input as other factors
			//	Can change the direction of the character. [orig]
			//	Should they?  Fine for now, but I think the Character should be in control of their direction more fully perhaps? [Vortex]
			anim.SetFloat("MoveDirX", inputVector.x);
			anim.SetFloat("MoveDirY", inputVector.y);

			Debug.Log(inputVector);

			walkVector = inputVector;
		}
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
		//set the values of activeAbilities in Start()
		rigidBody = GetComponent<Rigidbody2D>();
		velocity = Vector2.zero;
		anim = GetComponent<Animator>();
		anim.SetFloat("MoveDirY", -1);
		stances = GetComponents<Stance>();
		currentStance = 0;
		ActivateStance(stances[currentStance]);
	}
	////Vectors for debugging speed
	//Vector3 lastPosition;
	//Vector3 currentPosition;
	private void Update()
	{
		if (isWalking)
		{
			anim.SetBool("isWalking", true);
		}
		else {
			anim.SetBool("isWalking", false);
		}
		//Debug.Log("Distance moved since last frame: " + ((transform.position - lastPosition) * 1000));
	}


	private void FixedUpdate()  //only contains Movement code atm
	{
		if (isWalking)
		{
			//Add the character's speed
			velocity += walkVector;
		}
		//Normalizes the velocity so that you don't move faster when moving diagonally
		velocity.Normalize();

		//Take the sum total of the effects on velocity this timestep
		rigidBody.MovePosition(rigidBody.position + velocity * speed * Time.deltaTime);

		//Once finished moving, make sure that isWalking is set to false
		isWalking = false;
		//Set velocity back to zero so it can be re-evaluated next frame;
		velocity = Vector2.zero;
	}
}