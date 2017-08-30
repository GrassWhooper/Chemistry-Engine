using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_Engine
{
    //whatever interactions, are possible, 

    interface IFlameable//called on collision with fire
    {
        void Flame();
    }
    interface IWetable//called on collision with water
    {
        void Wet();
    }
}