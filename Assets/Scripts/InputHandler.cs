using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Sets up the use of inputs to manipulate a Character
/// <para>Use the Edit > Project Settings > Input menu to define Axes and Buttons so that it remains user-configurable</para>
/// </summary>
public class InputHandler : MonoBehaviour {

	private Character character;
	public static bool isInMenu = false;	//Probably best to make this a GameManager variable

	void Start() {
		character = GetComponent<Character>();
		Debug.Log(character.gameObject);
	}	
	
	void Update() {
		CheckForMenus();
		if (isInMenu == false) {
			//
			CheckForMovement();
			CheckForStanceSwitch();
			CheckForAbility();
		} else {
			//Dummy code for menu input
			CheckForMenuNav();
			CheckForMenuSwitch();
		}
	}

	#region UI and Menu Controls
	
	//Basic way to make a menu activate
	private void CheckForMenus() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (isInMenu == false) {
				Debug.Log("Escape Menu activated");
			}
			isInMenu = !isInMenu;
		}
		if(Input.GetKeyDown(KeyCode.Tab)) {
			//Go to Tab menu
		}
	}

	private void CheckForMenuNav() { }
	private void CheckForMenuSwitch() { }
	#endregion

	#region Character and Gameplay Controls

	private void CheckForMovement() {

		var velocity = new Vector2();

		// Will probably consider using ".GetAxisRaw" instead? This has a smoothing effect
		// Which means you don't stop straight away
		velocity.x = Input.GetAxis("Horizontal");
		velocity.y = Input.GetAxis("Vertical");

		if (velocity != Vector2.zero) {
			character.AddVelocity(velocity);
		}
	}

	private void CheckForStanceSwitch() {
		if		(Input.GetButtonDown("NextStance"))
		{
			character.SwitchStance();
		}
		else if (Input.GetButtonDown("PrevStance"))
		{
			character.SwitchStance(false);
		}
	}

	private void CheckForAbility() {
		if		(Input.GetButtonDown("Ability1")) {
			character.UseAbility(0);
		} 
		else if (Input.GetButtonDown("Ability2")) {
			character.UseAbility(1);
		}
	}
	#endregion
}
