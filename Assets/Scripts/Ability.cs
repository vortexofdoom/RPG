using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an ability to operate.
/// </summary>
public abstract class Ability : MonoBehaviour {

	public Ability() {
		character = GetComponent<Character>();
	}

	private Character character;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
