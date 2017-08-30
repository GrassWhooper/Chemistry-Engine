using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_Engine
{
    //abstract element class, to be used in the polymorphsis
    //so that, we can have various different interactions, 
    //without needing to know, to call it specificlly
    //for all possible types.
    abstract class Element{}
    //different various elements, which are used, at the table, and in the collision process
    class Fire:Element{}
    class Water:Element{}
}