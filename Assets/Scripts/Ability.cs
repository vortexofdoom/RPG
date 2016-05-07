using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an ability to operate.
/// </summary>
public abstract class Ability  {

	private Character character;


    public Ability(Character charReference)
    {
        character = charReference;
    }
}
