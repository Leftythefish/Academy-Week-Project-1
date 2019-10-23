using System;
using System.Collections.Generic;
using Engine;

namespace Miniprojekti_1
{
    public class Program
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
            Window.CreateGameFinishedScreen(p);
            //Window.CreateGameOverScreen();
        }

        private static void PlayTheGame(Player p) //--Ria
        {
            //set the player in start position
            var startlocation = LocationByName("Dark Cave");
            p.CurrentLocation = startlocation;
            Window.EmptyStringData();
            do
            {
                p.Input = Console.ReadLine().ToLower(); ;
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
        public static void CreatePlayer(Player p)
        {
            Console.SetCursorPosition(51, 25);
            Console.WriteLine("Enter your name.");
            Console.SetCursorPosition(0, 29);
            string input = Console.ReadLine();
            CheckInput(input);
            p.Name = name;
            p.Max_Health = 100;
            p.Cur_Health = 100;
            Weapon Fists = new Weapon("Fist", "Fists", 2); // Jyri lisäsi, toivottavasti ei tuhoudu kaikki
            p.EquippedWeapon = Fists;
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


