using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Window
    {
        public static void CheckWindowSize()
        {
            if (Console.WindowHeight != 30 || Console.WindowWidth != 120)
            {
                Console.SetWindowSize(120, 30);
            }
        }
        public static void CreateMainScreen()
        {
            CheckWindowSize();
            Console.WriteLine(" ______________________________________________________________________________________________________________________");
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("Name: Joan");
            Console.SetCursorPosition(36, 1);
            Console.WriteLine("HP: 100/100");
            Console.SetCursorPosition(61, 1);
            Console.WriteLine("LVL: 1");
            Console.SetCursorPosition(90, 1);
            Console.WriteLine("EXP: 40/100");
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
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Beyond the stone wall a path twined through the brook, filling me with darkness");
            Console.SetCursorPosition(0, 29);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
