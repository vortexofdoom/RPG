using UnityEngine;
using System.Collections.Generic;
using System;

public class FireStance : Stance
{
    private string iconPath = "Sprites/Fire-Stance-Icon";

    public FireStance()
    {
        StanceName = "Fire";
            
        if (StanceIcon == null)
            StanceIcon = Resources.Load<Sprite>(iconPath);
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