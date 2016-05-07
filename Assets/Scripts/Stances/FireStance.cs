using UnityEngine;
using System.Collections.Generic;
using System;

public sealed class FireStance : Stance
{
    // I know this is probably new. But all it means is it calls the base constructor (Check the stance class)
    // With the charReference as the parameter. This was autoimlemented.
    public FireStance(Character charReference) : base(charReference)
    {

    }

    public override float Str()
	{
		return 1f;
	}
	public override float Agi()
	{
		return 2f;
	}
	public override float Pwr()
	{
		return 3f;
	}
}