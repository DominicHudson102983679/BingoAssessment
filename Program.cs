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

            string stringInput = Console.ReadLine();
            int input;

            if (int.TryParse(stringInput, out input))
            {} 
            else
            {
                Console.WriteLine("Not a number");
            }
            
            int upperLimit = input;
            Console.WriteLine();

            List<int> numList = new List<int>(upperLimit);
            List<int> removedList = new List<int>();
  
            for (int i = 1; i <= numList.Capacity; i++)
            {
                numList.Add(i);
            }
            
            Console.WriteLine("The numbers in this game will range from 1 to " + numList.Capacity);

            HomeMenu(upperLimit, numList, removedList);

            // home menu
            static void HomeMenu(int upperLimit, List<int> numList, List<int> removedList)
            {
                List<int> drawnIndex = new List<int> { };

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
                    DrawNext(numList, upperLimit, removedList);
                }
                else if (menuSelect == "2")
                {
                    ViewAllDrawn(removedList, numList, upperLimit);
                }
                else if (menuSelect == "3")
                {
                    CheckDrawn(upperLimit, numList, removedList);
                } 
                else if (menuSelect == "4")
                {
                    ExitApp();
                } 
                else
                {
                    InvalidMenuSelect(upperLimit, numList, removedList);
                }

            }

            static List<int> DrawNext(List<int> numList, int upperLimit, List<int> removedList)
            {
                Console.WriteLine("Press N to draw numbers");
                Console.WriteLine("Press E to go back to the menu");
                string drawNextSelect = Console.ReadLine();

                nextNum(drawNextSelect, numList, upperLimit, removedList);
                return removedList;
                
                static List<int> nextNum(string drawNextSelect, List<int> numList, int upperLimit, List<int> removedList)
                {
                    Console.ReadLine();
                    if (drawNextSelect == "n")
                    {
                        Random random = new Random();
                           
                        int num = numList[random.Next(numList.Count)];
                        int index = num - 1;

                        numList.Remove(num);
                        removedList.Add(num);
               
                        if (numList.Count < 1)
                        {
                            Console.WriteLine("The last number is: " + num);
                            Console.WriteLine();
                            Console.WriteLine("All numbers drawn. Returning to Home Menu");
                            HomeMenu(upperLimit, numList, removedList);
                            return numList;
                        }
                        else if (numList.Capacity > 1)
                        {
                            Console.WriteLine("Next number is: " + num);
                            string exit = Console.ReadLine();
                            if (exit == "e") 
                            {
                               HomeMenu(upperLimit, numList, removedList);
                            } 
                            else
                            
                            nextNum(drawNextSelect, numList, upperLimit, removedList);
                        }
                    }
                    return numList;
                }
            };


            static List <int> ViewAllDrawn(List<int> removedList, List <int> numList, int upperLimit)
            {
                Console.WriteLine("Enter any key to view numbers in the order they were drawn");
                Console.WriteLine("Enter 1 to view drawn numbers in numerical order ");

                string sortType = Console.ReadLine();

                Console.WriteLine("The numbers that have been drawn so far are:");
                if (sortType == "1") {
                    removedList.Sort();
                    foreach (object i in removedList)
                    {
                        Console.WriteLine(i);
                    };

                } 
                
                else
                {
                    foreach (object i in removedList)
                    {
                        Console.WriteLine(i);        
                    };
                }

                Console.WriteLine();
                Console.WriteLine("These numbers still need to be picked:");

                numList.Sort();
                foreach (object i in numList)
                {               
                    Console.WriteLine(i);
                };
 
                Console.WriteLine();
                Console.WriteLine("Returning to home menu");
                
                HomeMenu(upperLimit, removedList, numList);
                return removedList;
            };

            static void CheckDrawn(int upperLimit, List <int> numList, List <int> removedList)
            {
                Console.WriteLine("Input a number to see if its been drawn yet");
                
                int numCheck = Convert.ToInt32(Console.ReadLine());

                if (removedList.Contains(numCheck) == true)
                {   
                    Console.WriteLine(numCheck + " has already been drawn");
                    Console.WriteLine();
                } 
                else if (numCheck > numList.Capacity)
                {
                    Console.WriteLine("This number is not selectable in this Bingo game");
                } 
                else if (numCheck < 1)
                {
                    Console.WriteLine("This number is not selectable in this Bingo game");
                }
                else 
                {
                    Console.WriteLine(numCheck + " has not been drawn yet");
                    Console.WriteLine();
                }

                Console.WriteLine("-----------------------");
                Console.WriteLine();
                Console.WriteLine("Input e to exit");
                Console.WriteLine();
                Console.WriteLine("Input any other key to check another number");
                
                string exitCheckDrawn = Console.ReadLine();

                if (exitCheckDrawn == "e")
                {
                    HomeMenu(upperLimit, numList, removedList);
                }
                else 
                {
                    Console.WriteLine();
                    CheckDrawn(upperLimit, numList, removedList);
                } 
                    
            };


            static void ExitApp()
            {
                Console.WriteLine("Thank you for playing");
                Environment.Exit(0);
            };

            static void InvalidMenuSelect(int upperLimit, List<int> numList, List<int> removedList)
            {
                Console.WriteLine("Invalid option. Try Again");
                Console.WriteLine();
                HomeMenu(upperLimit, numList, removedList);
            }

        }
    }
}

