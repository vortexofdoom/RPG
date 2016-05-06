using UnityEngine;
using System.Collections.Generic;
using System;


public sealed class WaterStance : Stance
{
	//private string iconPath = "Sprites/Water-Stance-Icon";

	//public WaterStance()
	//{
	//	StanceName = "Water";

	//	if (StanceIcon == null)
	//		StanceIcon = Resources.Load<Sprite>(iconPath);
	//}
	
	public override float Str()
	{
		return 4f;
	}
	public override float Agi()
	{
		return 5f;
	}
	public override float Pwr()
	{
		return 6f;
	}
}