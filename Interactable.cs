using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_Engine
{
    //base, interactables class, 
    //which is used, to get whatever nessary implementations (interactions) that are implemented
    //if they don't exist, then, they won't be called. (or give a null issue).
    abstract class Interactable{}

    //different kinds of objects, that each have different implementations
    class Arrow : Interactable, IFlameable,IWetable
    {
        public void Flame()
        {
            Debug.Log("Woho, i am an arrow that just became on fire");
        }
        public void Wet()
        {
            Debug.Log("i am an arrow that just got wet");
        }
    }
    class Sword : Interactable, IWetable
    {
        public void Wet()
        {
            Debug.Log("i am a sword that looks shiny due to being wet");
        }
    }
}