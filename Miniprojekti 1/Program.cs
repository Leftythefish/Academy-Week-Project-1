using System;
using Engine;

namespace Miniprojekti_1
{
    class Program
    {
        public static string name;
        static void Main()
        {
            ///<summary>
            ///--Jesse--
            /// Main UI and it's components
            ///</summary>
            Player p = new Player();

            Window.CreateOpeningScreen();
            CreatePlayer(p);
            Console.SetCursorPosition(0, 29);
            Window.CreateMainScreen(p);
            Console.ReadKey();
            Window.CreateGameOverScreen();
        }
        static void CreatePlayer(Player p)
        {
            CheckInput();
            //Player p = new Player(name, 100);
            p.Name = name;
        }
        static string CheckInput()
        {
            Console.SetCursorPosition(51, 25);
            Console.WriteLine("Enter your name.");
            Console.SetCursorPosition(0, 29);
            string input = Console.ReadLine();
            if (input.Length < 26)
            {
                name = input;
                return name;
            }
            else
            {
                name = "";
                Console.SetCursorPosition(45, 26);
                Console.WriteLine("Please enter a shorter name!");
                Console.SetCursorPosition(0, 29);
                Console.WriteLine("                                                                                                                        ");
                CheckInput();
                return name;
            }
        }
    }
}
