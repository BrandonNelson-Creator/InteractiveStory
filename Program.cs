using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace InteractiveStory
{
    class Program
    {
        static int pageNumber = 0; 
        static string page;
        static string[] pageSection;
        static string output;
        static string choice1;
        static string choice2;
        static string destination1;
        static string destination2;
        static bool pathIsLinear;
        static string[] title = new string[]
        {
            "              /$$$$$$             /$$ /$$   /$$",
            "             /$$__  $$           | $$|__/  | $$",
            "             | $$ \\__/  /$$$$$$  | $$ /$$ /$$$$$$    /$$$$$$  /$$$$$$  / $$   / $$",
            "             |  $$$$$$ /$$__  $$ | $$| $$|_  $$_/   |____ $$ /$$__  $$ | $$   | $$",
            "             \\____  $$| $$  \\ $$ | $$| $$  | $$      /$$$$$$| $$ \\__/  | $$   | $$",
            "              /$$ \\ $$| $$  | $$ | $$| $$  | $$ /$$ /$$__ $$| $$       | $$   | $$",
            "             |  $$$$$$/|  $$$$$$/| $$| $$  |  $$$/ | $$$$$$$| $$       |  $$$$$$$",
            "              \\______/ \\______/  |__/|__/  \\___/  \\_______/|__/         \\____  $$",
            "                                                                        | $$$$$$/",
            "                                                                        \\______/",
            "                                     "

        };
        
        static int savedPage;
        static string[] story = new string[] { };
        static bool gameOver;

        static void Main(string[] args)
        {
            Menu();   
        }

        static void Save()
        {
            string save = pageNumber.ToString();
            // Writes to file
            File.WriteAllText("save.txt", save);
            Console.WriteLine("Game has been saved on: " + pageNumber);
            Console.ReadKey(true);
        }

        static void Load()
        {
            savedPage = int.Parse(File.ReadAllText("save.txt"));
            RunGame(savedPage);
        }

        static void Menu()
        {
            while (true)
            {


                Console.Clear();
                for (int i = 0; i < title.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(title[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("A - New Game");
                Console.WriteLine("L - Load Game");
                Console.WriteLine("Q - Quit");
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.A)
                {
                    if (CheckForFile("story.txt") == true)
                    {
                        RunGame(0);

                    }
                    else if (CheckForFile("story.txt") == false)
                    {
                        Console.WriteLine("Story Not Found!");
                        Console.ReadKey(true);
                       
                    }


                }
                else if (input.Key == ConsoleKey.L)
                {
                    Load();
                    //if (CheckForFile("save.txt") == false)


                }
                else if (input.Key == ConsoleKey.Q)
                {
                    QuitGame();
                }
                else if (input.Key != ConsoleKey.A && input.Key != ConsoleKey.L && input.Key != ConsoleKey.Q)
                {
                    InvaildInputMSG();
                    //Call "Menu()" because Main Menu does not have gameloop
                    Menu();
                }

                //Console.ReadKey(true);
            }
        }

        static void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game Over!");
            Console.WriteLine();
            Console.WriteLine("A - Main Menu");
            Console.WriteLine("B - Quit");
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.A)
            {
                Menu();
            }
            else if (input.Key == ConsoleKey.B)
            {
                QuitGame();
            }
            else if (input.Key != ConsoleKey.A && input.Key != ConsoleKey.B)
            {
                InvaildInputMSG();
                //Calls "GameOver()" because GameOver does not have gameloop

                GameOver();
            }
        }

        static bool CheckForFile(string file)
        {
            if (File.Exists(file))
            {
                return true;
                
            }
            return false;

        }

        static void InvaildInputMSG()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Invaild Keypress");
            Console.ReadKey(true);
        }

        static void QuitGame()
        {
            
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Beep(2500, 250);
            Console.Beep(2000, 250);
            Console.Beep(1500, 250);

            Console.WriteLine("Quit");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
       

        static void RunGame(int value)
        {
            pageNumber = value;
            story = File.ReadAllLines("story.txt");
            //GameLoop
            while (gameOver == false)
            {

                page = story[pageNumber];
                pageSection = page.Split(';');
                output = pageSection[0];
                choice1 = pageSection[1];
                choice2 = pageSection[2];
                destination1 = pageSection[3];
                destination2 = pageSection[4];
                

                int parseNumber = int.Parse(destination1);
                int parseNumber1 = int.Parse(destination2);

               
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Current Page: " + pageNumber);
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine(output);
               
                if (pageNumber == 8)
                {
                    Console.ReadKey(true);
                    break;
                    
                }
                if (pageNumber == 10)
                {
                    Console.ReadKey(true);
                    break;

                }
                if (pageNumber == 10 || pageNumber == 8) { gameOver = true; }
                if (pageNumber == 2 || pageNumber == 3 || pageNumber == 6 || pageNumber ==  9) { pathIsLinear = true; }
                else { pathIsLinear = false; gameOver = false; }
                Console.WriteLine();
                if (pathIsLinear) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("A - " + choice1); }
                else if (!pathIsLinear)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A - " + choice1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("B - " + choice2);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("S - Save");
                Console.WriteLine("Q - Quit");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("M - Main Menu");
            //Console.ReadKey(true);
            ConsoleKeyInfo input = Console.ReadKey(true);
                //Slections
                if(input.Key == ConsoleKey.A)
                {
                    pageNumber = parseNumber;
                    Console.Beep(2500, 250);
                }
                if (!pathIsLinear)
                {
                    if (input.Key == ConsoleKey.B)
                    {
                        pageNumber = parseNumber1;
                        Console.Beep(1500, 250);
                    }
                }
                
                if(input.Key == ConsoleKey.Q)
                {
                    QuitGame();
   
                }
                if (input.Key == ConsoleKey.S)
                {
                    Save();
                }
                if(input.Key == ConsoleKey.M)
                {
                    Menu();
                }
                if (gameOver == true)
                {
                    Console.Clear();
                    break;
                }
                else if(input.Key != ConsoleKey.A && input.Key != ConsoleKey.B && input.Key != ConsoleKey.Q && input.Key != ConsoleKey.S && input.Key != ConsoleKey.M  )
                {
                    InvaildInputMSG();
                }

            }            
                GameOver();
        }
    }
}
