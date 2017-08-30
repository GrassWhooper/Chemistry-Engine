using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_Engine
{
    //this class, handles all of the work of the collisions, where ever a collision happens, 
    //the engine, will just recieve it, and do the Work function on it.
    class Engine
    {
        //this is all of the possible interactions table
        //TODO: find how to fill it in a more dynamic way.
        Dictionary<CollisionData, List<Action<Interactable>>> interactionsTable = 
            new Dictionary<CollisionData, List<Action<Interactable>>>();
        public Engine()
        {
            //Definie Collisions Possible, and Add Them To Table
            
            //here, the Fire, and Arrow interaction/collision was defined, and added to table
            CollisionData d = new CollisionData(new Fire(), new Arrow());
            List<Action<Interactable>> callsOnData = new List<Action<Interactable>>();
            callsOnData.Add(Flamer);
            interactionsTable.Add(d, callsOnData);

            //here, the sword, and water interaction/collision was defined, and added to table
            callsOnData.Clear();
            d = new CollisionData(new Water(), new Sword());
            callsOnData.Add(Wetable);
            interactionsTable.Add(d, callsOnData);
        }
        //find if this interaction is defined, if it is then, play all of the actions that are inside of it.
        public void Work(Collision collision)
        {
            if (interactionsTable.ContainsKey(collision.data))
            {
                List<Action<Interactable>> interactions = interactionsTable[collision.data];
                foreach (Action<Interactable> interaction in interactions)
                {
                    interaction(collision.interactable);
                }
            }
            else
            {
                Debug.Log("Undefined interaction Between : " + collision.data.elementType
                    + " And " + collision.data.interactableType);
            }
        }
        #region InteractionsCalls
        //Gets the Flameable interface and calls it, allowing for each defined object to have its own,
        //different Flame call.
        public void Flamer(Interactable interactable)
        {
            IFlameable flameable = (interactable as IFlameable);
            if (flameable != null)
            {
                flameable.Flame();
            }
        }
        //same thing, but for Wetable.
        public void Wetable(Interactable interactable)
        {
            IWetable wetable = interactable as IWetable;
            if (wetable!=null)
            {
                wetable.Wet();
            }
        }
        #endregion
    }
}