using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
        static string[] menu = new string[]
        {"GAME TITLE!; START; QUIT"};

        static string[] story = new string[] 
        {"Waking up in a daze, you look around the cold, steel room, you notice the door to your room is gone and the main door is unlocked, " +
         "you get up to leave and notice there are more rooms like yours.; Leave the room; look around for anything useful; 1; 2",
         "Upon leaving you're startled by the dark and empty hallway, illuminated with only red revolving lights, theres a door to your left. ;" +
         " Continue down the hall; Check the door ; 3; 4",
                "the shop doesn't have any other treats.; Leave; ask the shop owner whats up?; 5; 6",
                "Timmy scream cause you are taking last vanilla cone;Slap his face;Throw Ice cream at him;4;4",
                "Cops arrest you for abusing a child;null;null;0;0"                                    };

        
        static void Main(string[] args)
        {
            RunGame();
           
        }
        static void Menu()
        {

            while (true)
            {

            }
        }

        static void RunGame()
        {
            
            while (true)
            {

                page = story[pageNumber];
                pageSection = page.Split(';');
                output = pageSection[0];
                choice1 = pageSection[1];
                choice2 = pageSection[2];
                destination1 = pageSection[3];
                destination2 = pageSection[4];
                choice1 = pageSection[]

                int parseNumber = int.Parse(destination1);
                int parseNumber1 = int.Parse(destination2);

               
                Console.Clear();
                Console.WriteLine("Brandon");
                Console.WriteLine(output);
                if (pageNumber == 4)
                {
                    Console.ReadKey(true);
                    break;
                }
                Console.WriteLine("A - " + choice1);
                Console.WriteLine("B - " + choice2);
                //Console.ReadKey(true);
                ConsoleKeyInfo input = Console.ReadKey();

                if(input.Key == ConsoleKey.A)
                {
                    pageNumber = parseNumber;
                    Console.Beep();
                }
                if (input.Key == ConsoleKey.B)
                {
                    pageNumber = parseNumber1;
                    Console.Beep();
                }
                if(input.Key == ConsoleKey.Q)
                {
                    break;
                }

                


            }
            Console.WriteLine("Game OVER!!!!");
            Console.ReadKey(true);
        }
    }
}
