using System;
using Engine;

namespace Miniprojekti_1
{
    class Program
    {
        static void Main(string[] args)
        {
        //Player p = new Player("Joan Jett Helvetinpitkänimi", 100);
            ///<summary>
            ///--Ria--
            /// Main UI and it's components, create more classes where necessary
            ///</summary>
            Window.CreateOpeningScreen();
            Console.SetCursorPosition(46, 25);
            Console.WriteLine("Press any key to start game.");
            Console.SetCursorPosition(0, 29);
            Console.ReadKey();
            Console.Clear();
            Window.CreateOpeningScreen();
            Console.SetCursorPosition(50, 25);
            Console.WriteLine("Enter your name.");
            Console.SetCursorPosition(0, 29);
            Console.ReadLine();
        }
    }
}
