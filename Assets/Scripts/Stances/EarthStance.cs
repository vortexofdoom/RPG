using UnityEngine;
using System.Collections.Generic;
using System;

public sealed class EarthStance : Stance
{
	//private string iconPath = "Sprites/Water-Stance-Icon";

	//public EarthStance()
	//{
	//	StanceName = "Earth";

	//	if (StanceIcon == null)
	//		StanceIcon = Resources.Load<Sprite>(iconPath);
	//}

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