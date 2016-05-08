using UnityEngine;
using System.Collections;

public class SimpleAI : MonoBehaviour {

	private Character character;
	
	// Use this for initialization
	void Start () {
		character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		character.AddVelocity(Vector2.right);
	}
}
