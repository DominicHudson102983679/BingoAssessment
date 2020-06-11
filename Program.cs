using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BingoAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick a number for the upper limit of this Bingo game");
            Console.WriteLine("The number must be higher than 1");
            Console.WriteLine("The number cannot be a non-numerical value");
            Console.WriteLine();

            int upperLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[] maxNum = new int[upperLimit];
            
            int[] notDrawnList = new int[upperLimit];

            int minNum = 0;
            int index = 0;
            int[] numArray = new int [upperLimit];
            
            
            while (minNum < maxNum.Length)
            {
                // i dont know how I got this to work but it just does somehow
                numArray[index] = upperLimit;
                Console.WriteLine(numArray[index]);
                index++;
                minNum++;
                upperLimit--;  
            }
            
            Console.WriteLine("The numbers in this game will range from 1 to " + numArray.Length);
            Console.WriteLine();

            HomeMenu(minNum, upperLimit, maxNum, numArray);

            // home menu
            static void HomeMenu(int minNum, int upperLimit, int [] maxNum, int [] numArray)
            {
                
                Console.WriteLine(" ");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("Welcome to the Swinburne Bingo Club");
                Console.WriteLine("1. Draw next number");
                Console.WriteLine("2. View all drawn numbers");
                Console.WriteLine("3. Check specific number");
                Console.WriteLine("4. Exit");
                Console.WriteLine(" ");
  
                string menuSelect = Console.ReadLine();
                Console.WriteLine();

                if (menuSelect == "1")
                {
                    DrawNext(numArray);             
                }
                else if (menuSelect == "2")
                {
                    ViewDrawn(maxNum);
                }
                else if (menuSelect == "3")
                {
                    CheckDrawn();
                } else if (menuSelect == "4")
                {
                    ExitApp();
                } else
                {
                    InvalidMenuSelect(minNum, upperLimit, maxNum, numArray);       
                }

            }

            static void DrawNext(int [] numArray)
            {
                
                Random drawRandom = new Random();

                // int[] notDrawnList = new int[numArray.Length];

                int drawnIndex = numArray[drawRandom.Next(numArray.Length)];
                Console.WriteLine(drawnIndex);
                int[] drawnList = new int[numArray.Length];
                Console.WriteLine("Press N to draw another number:");
                string drawAnother = Console.ReadLine();

                while (drawAnother == "N")
                {
                    Console.WriteLine("--------" + drawnIndex);
                }
                

                // drawRandom.Next(maxNum, maxNum.Length);

                // Console.WriteLine(maxNum[drawRandom]{ drawRandom });
                //int drawnNums = 
                
                // add number to list of selected numbers

                // return to DrawNext

                // draw another random number not already selected
                
            };


            static void ViewDrawn(int [] maxNum)
            {
                // int[] drawnList = new int[maxNum.Length];

                // return numbers collected from list in DrawNext
                Console.WriteLine();

            };


            static void CheckDrawn()
            {
                // check for specific number from list in DrawNext / if statement
                Console.WriteLine("__ has been drawn:");
            };


            static void ExitApp()
            {
                Console.WriteLine("closing application");
            };

            static void InvalidMenuSelect(int minNum, int upperLimit, int [] maxNum, int[] numArray)
            {
                Console.WriteLine("Invalid option. Try Again");
                Console.WriteLine();
                HomeMenu(minNum, upperLimit, maxNum, numArray);
            }






        }
    }
}

