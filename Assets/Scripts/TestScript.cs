using UnityEngine;
using System.Collections.Generic;

public class TestScript : MonoBehaviour{
	
    // Test script used to add stuff. This is for anything we haven't decided on the place for it to be created
    // Such as stances. It also acts as a way for use to hard code stuff in. Say we wanted to test a new ability we
    // Added. We can hard code it here and remove it later with no problem at all. 


    void Start()
    {
        var character = GetComponent<Character>();

        character.SetStance(0, new FireStance(character));
        character.SetStance(1, new WaterStance(character));
        character.SetStance(2, new EarthStance(character));

        character.ActivateStance(0);
    }

}