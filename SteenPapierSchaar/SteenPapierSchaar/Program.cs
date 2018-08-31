using System;
using System.Collections.Generic;
using System.Text;

namespace SteenPapierSchaar
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] strings = { "schaar", "steen", "papier" };
            String[][] asciiArt = new String[4][];
            asciiArt[0] = new string[] { "    _______", "-- -    ____)___", "          ______)", "       __________)", "      (____)", "-- -.__(___)" };
            asciiArt[1] = new string[] { "      _______", "-- - '   ____)", "      (_____)", "      (_____)", "      (____)", "-- -.__(___)" };
            asciiArt[2] = new string[] { "      _______", "-- -'    ____)___", "           ______)", "          _______)", "         _______)", "---.__________)" };
            asciiArt[3] = new string[] { "__      _______ ", "\\ \\    / / ____|", " \\ \\  / / (___  ", "  \\ \\/ / \\___ \\ ", "   \\  /  ____) |", "    \\/  |_____/ " };
            String cpuVSplayer = "" +
"   _____ _____   _    _                                       _____   _            __     ________ _____  " +
"\n  / ____ | __ \\ | |  | |                                      |  __\\ | |        /\\\\  \\   / /  ____|  __ \\ " +
"\n | |     | |__) | |  | |                                      | |__) | |       /  \\\\  \\_/ /| |__  | |__) |" +
"\n | |     | ___/ | |  | |                                      | ___/ | |      / /\\ \\\\    / |  __| | |  _ /" +
"\n | |____ | |    | |__| |                                      | |    | |____ / ____ \\|  |  | |____| | \\ \\ " +
"\n  \\_____ |_|     \\____/                                       |_|    |______/_/    \\_\\ _|  |______|_|  \\_\\";


            Random rnd = new Random();
            Boolean cont = true;
            int cpu_win = 0;
            int player_win = 0;
            int draw = 0;
            int rounds = 1;
            int turnCounter = 0;

            while (cont)
            {
                System.Console.Write("Round " + rounds + "  Draws: " + draw + " Cpu wins: " + cpu_win + " Player wins " + player_win);
                Console.WriteLine("\nEnter 1 for schaar, 2 for steen, 3 for papier, q to quit");
                int cpu = rnd.Next(0, 3);
                int playerC = 0;
                String player = Console.ReadLine();
                if (player == "q" || player == "1" || player == "2" || player == "3")
                {
                    if (player == "q")
                    {
                        break;
                    }
                    Console.WriteLine("Cpu chose: " + strings[cpu] + " Player chose: " + strings[(playerC = Int32.Parse(player)) - 1]);
                    if ((cpu == 0 && player == "1") || (cpu == 1 && player == "2") || (cpu == 2 && player == "3"))
                    {
                        Console.WriteLine("Draw");
                        draw++;
                    }
                    if ((cpu == 0 && player == "3") || (cpu == 1 && player == "1") || (cpu == 2 && player == "2"))
                    {
                        Console.WriteLine("Cpu wins!");
                        cpu_win++;
                    }
                    if ((cpu == 0 && player == "2") || (cpu == 1 && player == "3") || (cpu == 2 && player == "1"))
                    {
                        Console.WriteLine("Player wins!");
                        player_win++;
                    }

                    Console.WriteLine(cpuVSplayer + "\n");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write("\n" + asciiArt[cpu][i] + "                 ");
                        Console.SetCursorPosition(30, Console.CursorTop);
                        Console.Write(asciiArt[3][i]);
                        Console.SetCursorPosition(63, Console.CursorTop);
                        Console.Write(asciiArt[(Int32.Parse(player) - 1)][i]);

                    }
                    System.Threading.Thread.Sleep(3000);
                    rounds++;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Try again!");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                }


            }
            Console.WriteLine("Calculating the statistics");
            demoPercentDone();
            for (int i = 0; i < 10; i++)
            {
                Turn();
            }
            rounds--;
            if (rounds == 0)
            {
                Console.WriteLine("Y U NO PLAY");
            }else
            {
                int drawPercent = (draw * 100) / (rounds);
                Console.WriteLine("Final statistics: " + "\nRounds played: " + rounds + "\nDraws: " + drawPercent
                    + "%\nCpu wins: " + ((cpu_win * 100) / rounds) + "%\nPlayer wins: " + ((player_win * 100) / rounds) + "%");
            }
            
            Console.ReadLine();

            void demoPercentDone()
            {
                for (int i = 0; i < 101; i++)
                {
                    System.Console.Write("\rProcessing {0}%...", i);
                    System.Threading.Thread.Sleep(10);
                }
                System.Console.WriteLine();
            }


            void Turn()
            {

                turnCounter++;
                switch (turnCounter % 4)
                {
                    case 0: Console.Write("/"); turnCounter = 0; break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }

        }
    }
}
