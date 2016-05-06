using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an Stance to operate.
/// </summary>
public class Stance : MonoBehaviour
{	
	public Stance() {
		
	}
		
	public string StanceName { get; protected set; }

	// will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
	public Sprite StanceIcon { get; protected set; }
	
	public virtual float Str() { return 0f; }
	public virtual float Agi() { return 0f; }
	public virtual float Pwr() { return 0f; }

	private Character character;

	void Start()
	{
		character = GetComponent<Character>();
	}
}