using UnityEngine;
using System.Collections.Generic;
using System;

public sealed class EarthStance : Stance
{
    // I know this is probably new. But all it means is it calls the base constructor (Check the stance class)
    // With the charReference as the parameter. This was autoimlemented.
    public EarthStance(Character charReference) : base(charReference)
    {

    }


    public override float Str()
	{
		return 7f;
	}
	public override float Agi()
	{
		return 8f;
	}
	public override float Pwr()
	{
		return 9f;
	}
}