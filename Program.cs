﻿using System;
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
        //Pg0
        {"Waking up in a daze, you look around the cold, steel room, you notice the door to your room is gone and the main door is unlocked, you get up to leave and notice there are more rooms like yours.; Leave the room; look around for anything useful; 1; 2",
        //Pg1
         "Upon leaving you're startled by the dark and empty hallway, illuminated with only red revolving lights, theres a door to your left. ; Check the door; Continue down the hall; 3; 4",
         //Pg2
         "When checked you find a flashlight!; Leave the room; Leave the room; 1; 1",
         //Pg3
         "The door is locked; Continue down the hall; ; 4; 4",
         //Pg4
         "Down the hall you see other doors but none seem to be active, but at the end you see an open stairwell to your right; Go down stairs; Check the door; 5; 6",
         //Pg5
         "At the bottom you're greeted with an empty ambiance, a dark large open area with crates, theres a narrow path on your left and straight ahead from the stairs the catwalk seems to be broken.; Squeeze down path; attempt to jump gap; 7; 8",
         //Pg6
         "The door is offline.; Go down stairs; ; 5; 5",
         //Pg7
         "The narrow path was tight but you find a massive breaker switch thats halfway.; Leave room and attempt gap.; Power on Breaker.; 8; 9",
         //Pg8
          "You attemped the gap but realize you can't jump and end up falling and breaking your neck.; null; null; 0; 0"};

         

        
        static void Main(string[] args)
        {
           
            RunGame();
           
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
                

                int parseNumber = int.Parse(destination1);
                int parseNumber1 = int.Parse(destination2);

               
                Console.Clear();
                Console.WriteLine("Brandon");
                Console.WriteLine(output);
                if (pageNumber == 8)
                {
                    Console.ReadKey(true);
                    break;
                    Console.WriteLine("ame OVER!!!!");
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
                    Console.WriteLine("uit")
                }

                


            }
            
            Console.ReadKey(true);
        }
    }
}
