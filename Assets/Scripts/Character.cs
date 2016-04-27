/*
    Player, and NPCs can be sub-classes of this.

                        Nostro Vostro(Trevor)
*/
using UnityEngine;
using System.Collections;

namespace RPG.Character
{
    public abstract class Character
    {

        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /*
            Character variables, such as stats will go in this area.
            
            Stats could be stored as an array  : stats will have to be referenced by number, could be confusing
            
            Stats could be sroted as a Dictionary : stats will be referenced by their name(i.e stats["Statname"])

            Stats could be stored Individually : stats will be referenced by their name(i.e health, mana, etc..)
        */
    }
}
