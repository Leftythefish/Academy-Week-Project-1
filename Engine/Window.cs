using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Window
    {
        public static string line1;
        public static string line2;
        public static string line3;
        public static string line4;
        public static string line5;
        public static string line6;
        public static string line7;
        public static string line8;
        public static string line9;
        public static string line10;
        public Window()
        { }


        public static void CheckWindowSize()
        {
            if (Console.WindowHeight != 30 || Console.WindowWidth != 120)
            {
                Console.SetWindowSize(120, 30);
            }
        }

        public static void CreateOpeningScreen()
        {
            CheckWindowSize();
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("________________________________________________________________________________________________________________________");
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("________________________________________________________________________________________________________________________");

            for (int i = 2; i <= 27; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
            }

            for (int i = 2; i <= 27; i++)
            {
                Console.SetCursorPosition(119, i);
                Console.WriteLine("|");
            }
            for (int i = 2; i <= 27; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.WriteLine("|");
            }

            for (int i = 2; i <= 27; i++)
            {
                Console.SetCursorPosition(118, i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(26, 10);
            Console.WriteLine(@"________                           ____  __.__.__  .__                ");
            Console.SetCursorPosition(26, 11);
            Console.WriteLine(@"\_____  \    ___________   ____   |    |/ _|__|  | |  |   ___________ ");
            Console.SetCursorPosition(26, 12);
            Console.WriteLine(@" /   |   \  / ___\_  __ \_/ __ \  |      < |  |  | |  | _/ __ \_  __ \");
            Console.SetCursorPosition(26, 13);
            Console.WriteLine(@"/    |    \/ /_/  >  | \/\  ___/  |    |  \|  |  |_|  |_\  ___/|  | \/");
            Console.SetCursorPosition(26, 14);
            Console.WriteLine(@"\_______  /\___  /|__|    \___  > |____|__ \__|____/____/\___  >__|   ");
            Console.SetCursorPosition(26, 15);
            Console.WriteLine(@"        \//_____/             \/          \/                 \/       ");
        }
        public static void CreateMainScreen(Player p)
        {
            Console.Clear();
            CheckWindowSize();
            Console.WriteLine(" ______________________________________________________________________________________________________________________");
            Console.SetCursorPosition(2, 1);
            Console.WriteLine($"Name: {p.Name}");
            Console.SetCursorPosition(36, 1);
            Console.WriteLine($"HP: {p.Cur_Health}/{p.Max_Health}");
            Console.SetCursorPosition(61, 1);
            Console.WriteLine("LVL: 1");
            Console.SetCursorPosition(90, 1);
            Console.WriteLine($"EXP: {p.Exp}/100");
            Console.WriteLine("________________________________________________________________________________________________________________________");
            for (int i = 1; i <= 2; i++)
            {
                Console.SetCursorPosition(34, i);
                Console.WriteLine("|");
            }
            for (int i = 1; i <= 2; i++)
            {
                Console.SetCursorPosition(88, i);
                Console.WriteLine("|");
            }

            for (int i = 1; i <= 2; i++)
            {
                Console.SetCursorPosition(59, i);
                Console.WriteLine("|");
            }

            for (int i = 1; i <= 27; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
            }

            for (int i = 1; i <= 27; i++)
            {
                Console.SetCursorPosition(119, i);
                Console.WriteLine("|");
            }
            Console.WriteLine("________________________________________________________________________________________________________________________");
            //Game text:
            line1 = "Far away a stream twirled through the ravine, filling me with merriment";
            line10 = "Behind me a path weaved through the stream, filling me with reflections";
            Console.SetCursorPosition(3, 4);
            Console.WriteLine(line1);
            Console.SetCursorPosition(3, 5);
            Console.WriteLine(line2);
            Console.SetCursorPosition(3, 6);
            Console.WriteLine(line3);
            Console.SetCursorPosition(3, 7);
            Console.WriteLine(line4);
            Console.SetCursorPosition(3, 8);
            Console.WriteLine(line5);
            Console.SetCursorPosition(3, 9);
            Console.WriteLine(line6);
            Console.SetCursorPosition(3, 10);
            Console.WriteLine(line7);
            Console.SetCursorPosition(3, 11);
            Console.WriteLine(line8);
            Console.SetCursorPosition(3, 12);
            Console.WriteLine(line9);
            Console.SetCursorPosition(3, 13);
            Console.WriteLine(line10);
            Console.SetCursorPosition(0, 29);
            Console.ReadLine();
        }
        
        public static void UpdateHp(Player p)
        {
            Console.SetCursorPosition(36, 1);
            Console.WriteLine("HP:     ");
            Console.SetCursorPosition(36, 1);
            Console.WriteLine($"HP: {p.Cur_Health}/{p.Max_Health}");
        }

        public static void UpdateExp()
        {

        }
    }
}