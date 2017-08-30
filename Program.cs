using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chemistry_Engine
{
    //helper function, because i am so used to writing Debug.Log("string"); on unity :D
    static class Debug
    {
        public static void Log(string s)
        {
            Console.WriteLine(s);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //we start, the engine, which contains all of the definitions,
            //of the possible interactions, and can do work, on any collision, 
            //that happens all over the game, the work being, whatever is defined.
            //for the object itself to do
            Engine engine = new Engine();

            //define some collisions, and do work on them.
            //which, calls the interfaces, on each object, for the specific interaction,
            //only if the interaction is defined at the engine.
            Collision fireArrowCollision = new Collision(new Fire(), new Arrow());
            engine.Work(fireArrowCollision);

            Collision waterSwirdCollision = new Collision(new Water(), new Sword());
            engine.Work(waterSwirdCollision);

            Collision waterArrowCollision = new Collision(new Water(), new Arrow());
            engine.Work(waterArrowCollision);

            Collision fireSwordCollision = new Collision(new Fire(), new Sword());
            engine.Work(fireSwordCollision);

            Console.ReadLine();
        }
    }
}