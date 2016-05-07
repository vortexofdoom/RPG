using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class PhysicalAbility : Ability
{
	protected override abstract void AbilityImplementation(); //Passing the buck on the Ability Implementation


}