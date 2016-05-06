using UnityEngine;
using System.Collections;

namespace RPGtest {

	/// <summary>
	/// <para>Abstract Class for defining other stances</para>
	/// <para>Must include public override floats for each stat</para>
	/// <para>Optional void StanceFunction for defining Stance-specific behavior</para>
	/// <para>Also gives all derived classes a character that their functions can access</para>
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public abstract class Stance : MonoBehaviour
	{
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

	public class FireStance : Stance 
	{
		public override float Str() {
			return 1f;
		}
		public override float Agi() {
			return 2f;
		}
		public override float Pwr() {
			return 3f;
		}

		public override void StanceFunctions() {} 
	}

	public class WaterStance : Stance
	{
		public override float Str() {
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

	public class EarthStance : Stance
	{
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

	public class Character : MonoBehaviour {

		//Primal Stats
		private float primalStat1;
		private float primalStat2;

		//Base Stats that combat uses
		private float str;	//Strength	(for things like HP and physical abilities)
		private float agi;	//Agility	(possibly for things like movement Speed)
		private float pwr;	//Power		(for non-physical abilities)

		private Stance currentStance;	//Variable to assign your current stance to and call functions from
		//one way to include stances in a character, hardcoded right now
		private Stance fireStance = new FireStance();
		private Stance waterStance = new WaterStance();
		private Stance earthStance = new EarthStance();
		
		//can use this to drag Stance derived scripts into the inspector
		public Stance[] stances;

		void Start() {
			
		}
		void Buff() {
			//A super basic example of what this formula is supposed to do, this could even be base constructor
		}

		void ActivateStance(Stance someStance) {
			str = someStance.Str();
			agi = someStance.Agi();
			pwr = someStance.Pwr();
			Debug.Log(someStance + " currently active");
		}

		void SwitchStance() {
			int max = stances.Length;
			for (int i = 0; i < max - 1; i++)
			{
				if (i != max) {
					currentStance = stances[i + 1];
				} else {
					currentStance = stances[0];
				}
				Debug.Log("Current Stance: " + currentStance);
				ActivateStance(currentStance);
			}
		}

		void Update()
		{
			//checking if the input is asking for a stance change, here represented by a quick and dirty spacebar check
			//Need to plug input back in
			//the idea of pulling it out of update directly is to set these character-bound variables once per stance change
			//then leave them until next time the stance changes, rather than calculating every frame
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SwitchStance();
			}
		}
	}
}

//public sealed class WaterStance : Stance
//{
//	private string iconPath = "Sprites/Water-Stance-Icon";

//	public WaterStance()
//	{
//		StanceName = "Water";

//		if (StanceIcon == null)
//			StanceIcon = Resources.Load<Sprite>(iconPath);
//	}

//	public override float Str()
//	{
//		return ((character.primalStat1 * 2) + (character.primalStat2 * 3)) / 2;
//	}
//	public override float Agi()
//	{
//		return ((character.primalStat2) + (character.primalStat3 * 4)) / 2;
//	}
//	public override float Pwr()
//	{
//		return (character.primalStat3 * 2);
//	}
//}
