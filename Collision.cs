using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_Engine
{
    //the collision itself, (can be swapped, by unity's collision, or on Trigger event or whatever).
    class Collision
    {
        //the data of the collision (a special struct, defined, that holds the type
        //Element, and the object.
        public CollisionData data;
        //the interactable object iself (can be sword, arrow, whatever)
        public Interactable interactable;
        public Collision(Element element,Interactable interactable)
        {
            data = new CollisionData(element,interactable);
            this.interactable = interactable;
        }
    }
}