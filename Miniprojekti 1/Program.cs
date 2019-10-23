using System;
using System.Collections.Generic;
using Engine;

namespace Miniprojekti_1
{
    class Program
    {
        
        public static World Cave = new World();
        public static string name;
        static void Main()
        {
            ///<summary>
            ///--Jesse--Ria--
            /// Main UI and it's components
            ///</summary>
            Player p = new Player();

            Window.CreateOpeningScreen();
            CreatePlayer(p);
            Console.SetCursorPosition(0, 29);
            Window.CreateMainScreen(p);
            //Create the world
            Cave.CreateWorlds();
            PlayTheGame(p);
            Console.ReadKey();
            Window.CreateGameOverScreen();
        }

        private static void PlayTheGame(Player p) //--Ria
        {
            //set the player in start position
            var startlocation = LocationByName("Dark Cave");
            p.CurrentLocation = startlocation;
            Window.EmptyStringData();
            do
            {
            p.Input = Console.ReadLine();
            PlayerActions.ReadInput(p);
            } while (p.Cur_Health > 0);
            
        }


        public static Location LocationByName(string name)
        {
            foreach (Location location in Cave.WorldList)
            {
                if (location.Name == name)
                {
                    return location;
                }
            }
            return null;
        }

        static void CreatePlayer(Player p)
        {
            CheckInput();
            //Player p = new Player(name, 100);
            p.Name = name;
            p.Max_Health = 100;
            p.Cur_Health = 100;
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
