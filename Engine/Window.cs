using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Window
    {
        ///<summary>
        ///--Jesse
        ///</summary>
        public static string[] lines = new string[10];
        public static string line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12, line13, line14, line15, line16, line17;
        public Window() { }
        public static void EmptyGameTextFromScreen()
        {
            for (int i = 4; i < 21; i++)
            {
                Console.SetCursorPosition(3, i);
                Console.WriteLine("                                                                                                                    ");
            }
            Console.SetCursorPosition(0, 29);
            Console.Write("                                                                                                                        ");
        }
        public static void InsertGameTextToScreen()
        {
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
            Console.SetCursorPosition(3, 14);
            Console.WriteLine(line11);
            Console.SetCursorPosition(3, 15);
            Console.WriteLine(line12);
            Console.SetCursorPosition(3, 16);
            Console.WriteLine(line13);
            Console.SetCursorPosition(3, 17);
            Console.WriteLine(line14);
            Console.SetCursorPosition(3, 18);
            Console.WriteLine(line15);
            Console.SetCursorPosition(3, 19);
            Console.WriteLine(line16);
            Console.SetCursorPosition(3, 20);
            Console.WriteLine(line17);
            Console.SetCursorPosition(0, 29);
        }
        public static void InsertGameTextToScreenArray()
        {
            Console.SetCursorPosition(3, 4);
            Console.WriteLine(lines[0]);
            Console.SetCursorPosition(3, 5);
            Console.WriteLine(lines[1]);
            Console.SetCursorPosition(3, 6);
            Console.WriteLine(lines[2]);
            Console.SetCursorPosition(3, 7);
            Console.WriteLine(lines[3]);
            Console.SetCursorPosition(3, 8);
            Console.WriteLine(lines[4]);
            Console.SetCursorPosition(3, 9);
            Console.WriteLine(lines[5]);
            Console.SetCursorPosition(3, 10);
            Console.WriteLine(lines[6]);
            Console.SetCursorPosition(3, 11);
            Console.WriteLine(lines[7]);
            Console.SetCursorPosition(3, 12);
            Console.WriteLine(lines[8]);
            Console.SetCursorPosition(3, 13);
            Console.WriteLine(lines[9]);
            Console.SetCursorPosition(0, 29);
        }
        public static void EmptyStringData()
        {
            line1 = "";
            line2 = "";
            line3 = "";
            line4 = "";
            line5 = "";
            line6 = "";
            line7 = "";
            line8 = "";
            line9 = "";
            line10 = "";
            line11 = "";
            line12 = "";
            line13 = "";
            line14 = "";
            line15 = "";
            line16 = "";
            line17 = "";
            lines[0] = "";
            lines[1] = "";
            lines[2] = "";
            lines[3] = "";
            lines[4] = "";
            lines[5] = "";
            lines[6] = "";
            lines[7] = "";
            lines[8] = "";
            lines[9] = "";
        }
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
            Console.SetCursorPosition(15, 3);
            Console.WriteLine(@"                          __,='`````'=/__                                      ");
            Console.SetCursorPosition(15, 4);
            Console.WriteLine(@"                         '//  (o) \(o) \ `'        _,-,                         ");
            Console.SetCursorPosition(15, 5);
            Console.WriteLine(@"                         //|     ,_)   (`\     ,-'`_,-\                         ");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine(@"                       ,-~~~\  `'==='  /-,      \==````\__                      ");
            Console.SetCursorPosition(15, 7);
            Console.WriteLine(@"                      /        `----'     `\     \      \/                      ");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine(@" ____  __.__.__  .__ /    __  .__           \ ____\____  \                      ");
            Console.SetCursorPosition(15, 9);
            Console.WriteLine(@"|    |/ _|__|  | |  |   _/  |_|  |            \      \    \                     ");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine(@"|    |/ _|__|  | |  |   _/  |_|  |__   ____   \_____  \    \__________   ____   ");
            Console.SetCursorPosition(15, 11);
            Console.WriteLine(@"|      < |  |  | |  |   \   __\  |  \_/ __ \   /   |   \  / ___\_  __ \_/ __ \  ");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine(@"|    |  \|  |  |_|  |__  |  | |   Y  \  ___/  /    |    \/ /_/  >  | \/\  ___/  ");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine(@"|____|__ \__|____/____/  |__| |___|  /\___  >,\_______  /\___  /|__|    \___  > ");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine(@"        \/         (               \/     \/>` _,`    \//_____/             \/  ");
            Console.SetCursorPosition(15, 15);
            Console.WriteLine(@"                  ,`    ,/,              ,>,_,`)       \--`````\                ");
            Console.SetCursorPosition(15, 16);
            Console.WriteLine(@"                  (      `\`---'`  `-,-'`_,<   \        \_,.--'`                ");
            Console.SetCursorPosition(15, 17);
            Console.WriteLine(@"                   `.      `--. _,-'`_,-`  |    \                               ");
            Console.SetCursorPosition(15, 18);
            Console.WriteLine(@"                    [`-.___   <`_,-'`------(    /                               ");
            Console.SetCursorPosition(15, 19);
            Console.WriteLine(@"                    (`` _,-\   \ --`````````|--`                                ");
            Console.SetCursorPosition(15, 20);
            Console.WriteLine(@"                     >-`_,-`\,-` ,          |                                   ");
            Console.SetCursorPosition(15, 21);
            Console.WriteLine(@"                   <`_,'     ,  /\          /                                   ");
            Console.SetCursorPosition(15, 22);
            Console.WriteLine(@"                    `  \/\,-/ `/  \/`\_/V\_/                                    ");
            Console.SetCursorPosition(15, 23);
            Console.WriteLine(@"                       (  ._. )    ( .__. )                                     ");
            Console.SetCursorPosition(15, 24);
            Console.WriteLine(@"                       |      |    |      |                                     ");
            Console.SetCursorPosition(15, 25);
            Console.WriteLine(@"                        \,---_|    |_---./                                      ");
            Console.SetCursorPosition(5, 26);
            Console.WriteLine(@"Original artwork by Zeus          ooOO(_)    (_)OOoo                                      ");
            Console.SetCursorPosition(80, 17);
            Print("Part II: Escaping the Cave", 70);
            Console.SetCursorPosition(70, 23);
            Print("Press any key to start game.", 70);
            Console.SetCursorPosition(0, 29);
            Console.ReadKey();
            Console.SetCursorPosition(60, 25);
            Console.WriteLine("                                  ");
        }
        public static void CreateGameFinishedScreen(Player p)
        {
            CheckWindowSize();
            Console.Clear();
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
            Console.SetCursorPosition(17, 7);
            Console.WriteLine($"Congratulations {p.Name}!");
            Console.SetCursorPosition(5, 10);
            Console.WriteLine(@"_____.___.              .__                                                                       .___");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine(@"\__  |   | ____  __ __  |  |__ _____ ___  __ ____     ____   ______ ____ _____  ______   ____   __| _/");
            Console.SetCursorPosition(5, 12);
            Console.WriteLine(@" /   |   |/  _ \|  |  \ |  |  \\__  \\  \/ // __ \  _/ __ \ /  ___// ___\\__  \ \____ \_/ __ \ / __ | ");
            Console.SetCursorPosition(5, 13);
            Console.WriteLine(@" \____   (  <_> )  |  / |   Y  \/ __ \\   /\  ___/  \  ___/ \___ \\  \___ / __ \|  |_> >  ___// /_/ | ");
            Console.SetCursorPosition(5, 14);
            Console.WriteLine(@" / ______|\____/|____/  |___|  (____  /\_/  \___  >  \___  >____  >\___  >____  /   __/ \___  >____ | ");
            Console.SetCursorPosition(5, 15);
            Console.WriteLine(@" \/                          \/     \/          \/       \/     \/     \/     \/|__|        \/     \/ ");
            Console.SetCursorPosition(5, 16);
            Console.WriteLine(@"  __  .__             _________     _________   _______________                                       ");
            Console.SetCursorPosition(5, 17);
            Console.WriteLine(@"_/  |_|  |__   ____   \_   ___ \   /  _  \   \ /   /\_   _____/                                       ");
            Console.SetCursorPosition(5, 18);
            Console.WriteLine(@"\   __\  |  \_/ __ \  /    \  \/  /  /_\  \   Y   /  |    __)_                                        ");
            Console.SetCursorPosition(5, 19);
            Console.WriteLine(@" |  | |   Y  \  ___/  \     \____/    |    \     /   |        \                                       ");
            Console.SetCursorPosition(5, 20);
            Console.WriteLine(@" |__| |___|  /\___  >  \______  /\____|__  /\___/   /_______  /                                       ");
            Console.SetCursorPosition(5, 21);
            Console.WriteLine(@"           \/     \/          \/         \/                 \/                                        ");
            Console.SetCursorPosition(38, 25);
            Console.WriteLine("Press any key to play again or ESC to exit.");
            Console.SetCursorPosition(0, 29);
            var input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    CreateOpeningScreen();
                    //this must be replaced with a method that includes the entire game 
                    break;
            }
            Console.ReadLine();
        }
        public static void CreateGameOverScreen()
        {
            CheckWindowSize();
            Console.Clear();
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
            Console.SetCursorPosition(28, 10);
            Console.WriteLine(@"  ________                                                  ");
            Console.SetCursorPosition(28, 11);
            Console.WriteLine(@" /  _____/_____    _____   ____     _______  __ ___________ ");
            Console.SetCursorPosition(28, 12);
            Console.WriteLine(@"/   \  ___\__  \  /     \_/ __ \   /  _ \  \/ // __ \_  __ \");
            Console.SetCursorPosition(28, 13);
            Console.WriteLine(@"\    \_\  \/ __ \|  Y Y  \  ___/  (  <_> )   /\  ___/|  | \/");
            Console.SetCursorPosition(28, 14);
            Console.WriteLine(@" \______  (____  /__|_|  /\___  >  \____/ \_/  \___  >__|  )");
            Console.SetCursorPosition(28, 15);
            Console.WriteLine(@"        \/     \/      \/     \/                   \/       ");
            Console.SetCursorPosition(38, 25);
            Console.WriteLine("Press any key to exit.");
            Console.SetCursorPosition(0, 29);
            var input = Console.ReadKey(true);
            switch (input)
            {
                default:
                    Environment.Exit(0);
                    break;
            }
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
            Console.WriteLine($"LVL: {p.Level}");
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
            Console.SetCursorPosition(0, 29);
        }
        public static void InsertOpeningTexts()
        {
            EmptyGameTextFromScreen();
            line1 = "You slowly drift back to consciousness. You are cold and your head hurts.";
            line2 = "You look around and realize you are in a cave of some sort.";
            line3 = "You have your bag with you, but all your equipment is gone. You pick up a rock to be able to defend yourself.";
            line4 = "";
            line6 = "Type what you want to do and press ENTER:";
            line7 = "";
            line8 = "GO NORTH or N to move north";
            line9 = "GO EAST or E to move east";
            line10 = "GO SOUTH or S to move south";
            line11 = "GO WEST or W to move west";
            line12 = "LOOK AROUND or SEARCH to take a closer look at your surroundings";
            line13 = "ATTACK, or A to attack";
            line14 = "TALK to talk";
            line15 = "OPEN BAG, BAG or b to manage inventory";
            line16 = "HELP or H to open Help Menu";
            InsertGameTextToScreen();
        }
        public static void UpdateHp(Player p)
        {
            Console.SetCursorPosition(36, 1);
            Console.WriteLine("            ");
            Console.SetCursorPosition(36, 1);
            Console.WriteLine($"HP: {p.Cur_Health}/{p.Max_Health}");
        }
        public static void UpdateExp(Player p)
        {
            Console.SetCursorPosition(90, 1);
            Console.WriteLine("                          ");
            Console.SetCursorPosition(90, 1);
            Console.WriteLine($"EXP: {p.Exp}/100");
        }
        public static void UpdateLvl(Player p)
        {
            Console.SetCursorPosition(61, 1);
            Console.WriteLine("                         ");
            Console.SetCursorPosition(61, 1);
            Console.WriteLine($"LVL: {p.Level}");
        }
        public static void Print(string text, int speed)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
    }
}