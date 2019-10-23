using System;
using Engine;

namespace Miniprojekti_1
{
    public class Program
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
            Window.CreateGameFinishedScreen(p);
            //Window.CreateGameOverScreen();
        }
        public static void CreatePlayer(Player p)
        {
            Console.SetCursorPosition(51, 25);
            Console.WriteLine("Enter your name.");
            Console.SetCursorPosition(0, 29);
            string input = Console.ReadLine();
            CheckInput(input);
            p.Name = name;
        }
        public static string CheckInput(string input)
        {
            if (input.Length < 26)
            {
                name = input;
                return name;
            }
            else
            {
                name = "";
                Console.SetCursorPosition(45, 26);
                Console.Write("Please enter a shorter name!");
                Console.SetCursorPosition(0, 29);
                Console.Write("                                                                                                                        ");
                Console.SetCursorPosition(0, 29);
                string temp = Console.ReadLine();
                CheckInput(temp);
                return name;
            }
        }
    }
}
