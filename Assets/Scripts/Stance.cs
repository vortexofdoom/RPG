﻿using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an Stance to operate.
/// </summary>
[System.Serializable]
public class Stance
{	
	public string stanceName { get; set; }

	// will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
	public Sprite stanceIcon { get; set; }
	
	public virtual float Str() { return 0f; }
	public virtual float Agi() { return 0f; }
	public virtual float Pwr() { return 0f; }

	private Character character;

    /// <summary>
    /// Constructor taking the reference to the character creating this stance. 
    /// </summary>
    /// <param name="charReference">Reference to the character</param>
	public Stance(Character charReference)
    {
        character = charReference;
    }
}