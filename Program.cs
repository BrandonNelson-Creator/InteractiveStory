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
        static int freq = 256;
        static int dur = 400;

        static int pageNumber = 0; 
        static string page;
        static string[] pageSection;
        static string output;
        static string choice1;
        static string choice2;
        static string destination1;
        static string destination2;
        static bool pathIsLinear;
        

        static string[] story = new string[] { };
         //Main Story now in txt file
            //Pg0
            //{"Waking up in a daze, you look around the cold, steel room, you notice the door to your room is gone and the main door is unlocked, you get up to leave and notice there are more rooms like yours.; Leave the room; look around for anything useful; 1; 2",
            //Pg1
            //"Upon leaving you're startled by the dark and empty hallway, illuminated with only red revolving lights, theres a door to your left. ; Check the door; Continue down the hall; 3; 4",
            //Pg2
            //"When checked you find a flashlight!; Leave the room; Leave the room; 1; 1",
            //Pg3
            //"The door is locked; Continue down the hall; ; 4; 4",
            //Pg4
            //"Down the hall you see other doors but none seem to be active, but at the end you see an open stairwell to your right; Go down stairs; Check the door; 5; 6",
            //Pg5
            //"At the bottom you're greeted with an empty ambiance, a dark large open area with crates, theres a narrow path on your left and straight ahead from the stairs the catwalk seems to be broken.; Squeeze down path; attempt to jump gap; 7; 8",
            //Pg6
            //"The door is offline.; Go down stairs; 5; ",
            //Pg7
            //"The narrow path was tight but you find a massive breaker switch thats halfway.; Leave room and attempt gap.; Power on Breaker.; 8; 9",
            //Pg8
            //"You attemped the gap but realize you can't jump and end up falling and breaking your neck.; null; null; 0; 0",
            //Pg9
            //"The breaker makes a loud snap and you suddenly hear the roar of generators start and lights come on, you leave and go back up stairs, the door is now open.; Go to door; ; 10; 10",
            //Pg10
            //"Inside theres a red keycard, you are unsure of where to go... for now; null; null; 0; 0" };
            
        





        static void Main(string[] args)
        {
          
            RunGame();
           
        }
       

        static void RunGame()
        {
            story = File.ReadAllLines(@"story.txt");
            //GameLoop
            while (true)
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
                if (pageNumber == 2 || pageNumber == 3 || pageNumber == 6 || pageNumber ==  9) { pathIsLinear = true; }
                else { pathIsLinear = false; }
                if (pathIsLinear) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("A - " + choice1); }
                else if (!pathIsLinear)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A - " + choice1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("B - " + choice2);
                }
                //Console.ReadKey(true);
                ConsoleKeyInfo input = Console.ReadKey();
                //Slections
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
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Beep();
                    Console.Beep(256, 400);
                    break;
                    
                }


                


            }
            
            Console.WriteLine("Quit");
            Console.ReadKey(true);
        }
    }
}
