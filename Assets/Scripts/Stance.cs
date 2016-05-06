using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an Stance to operate.
/// </summary>
public abstract class Stance : MonoBehaviour
{		
	public string StanceName { get; protected set; }

	// will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
	public Sprite StanceIcon { get; protected set; }
	
	public abstract float Str();
	public abstract float Agi();
	public abstract float Pwr();

	private Character character;

	public virtual void StanceFunctions() { } //might be just as good to make this into one or more interfaces or give complete freedom to the new Stance creator

	void Start()
	{
		character = GetComponent<Character>();
	}
}
