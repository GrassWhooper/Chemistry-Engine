using System;

namespace Chemistry_Engine
{
    //the collision data class, which generally holds the types of the element, and interactable.
    struct CollisionData
    {
        public Type elementType;
        public Type interactableType;
        //only used to obtain the types of each part of the collision process
        public CollisionData(Element element, Interactable interactable) : this()
        {
            elementType = element.GetType();
            interactableType = interactable.GetType();
        }
        //these operators, are overridden so that, they work, speecially for the case we need
        //which is, having 2 collision datas being equal, only when 
        //each collision data instance, have the same element types, and interactable types
        //as the other collision data
        public static bool operator ==(CollisionData d1, CollisionData d2)
        {
            bool elementTypes, interactableTypes;
            GetTypesEqulibrium(d1, d2, out elementTypes, out interactableTypes);
            return elementTypes && interactableTypes;
        }
        public static bool operator !=(CollisionData d1, CollisionData d2)
        {
            bool elementTypeEqui, interactableTypesEqui;
            GetTypesEqulibrium(d1, d2, out elementTypeEqui, out interactableTypesEqui);
            return (elementTypeEqui && interactableTypesEqui == false);
        }
        //helper function, that returns, bools that tell whether the element types are equal or not
        //and whether the interactable types are equal or not.
        private static void GetTypesEqulibrium
            (CollisionData d1, CollisionData d2, out bool elementTypesEqui, out bool interactableTypesEqui)
        {
            elementTypesEqui = d1.elementType == d2.elementType;
            interactableTypesEqui = d1.interactableType == d2.interactableType;
        }

        //since we already have the operators defined, we need to also, override these functions
        //so that, the Dictionary, can know, that, 2 collision data instances, are the same or not
        //and the chosen way of making the table, is through comparing the collision data
        //(if we did not over ride these 2 functions, and operators, then, even if two  collision data instances
        //have the same exact types, then, they won't be marked as equal, making the dictionary, to fail, and 
        //be unable to obtain the key.
        public override bool Equals(object obj)
        {
            if (obj == null || obj is CollisionData == false)
            {
                return false;
            }
            return this == ((CollisionData)obj);
        }
        public override int GetHashCode()
        {
            //honestly, i just copied this, i didn't honestly understand, how this mathematical equation
            //works, but it doesn.
            //the main point of this mathematical equation is so that, 
            //the hashes, are unique, and are never the same, for any 2 instances of the 
            //collision data, that have different Element/interactable types.
            //and that, they are always equal, when 2 instances, of the collision data
            //have the same exact types (elements/interactable types).
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + elementType.GetHashCode();
                hash = hash * 31 + interactableType.GetHashCode();
                return hash;
            }
        }
    }
}