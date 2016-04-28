/*
    Player, and NPCs can be sub-classes of this.

                        Nostro Vostro(Trevor)
*/
using UnityEngine;
using System.Collections;

namespace RPG
{
    public abstract class Character
    {
        string name;
        public string Name { get { return name; } } // Would this ever need to be changed once a character is created?

        /*
            Character variables, such as stats will go in this area.
            
            Stats could be stored as an array  : stats will have to be referenced by number, could be confusing
            
            Stats could be sroted as a Dictionary : stats will be referenced by their name(i.e stats["Statname"])

            Stats could be stored Individually : stats will be referenced by their name(i.e health, mana, etc..)

            I feel like this should probably just go inside the Player script. No need to have it as a separate class.
            Trying to keep track of the differences between 'Character' and 'Player' could get confusing fast.
            Proposal: Move this data idea to the player script. 

            Also, is there any real need to have a base class for all 'people' in the game? The inheritance model is great, but doesn't
            fit game development as well as a component based system. 
        */
    }
}
