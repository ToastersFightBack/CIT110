using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinchAPI;

namespace Final
{
    class Program
    {
        //**************************************
        //Title: The Sneaky Finch
        //Application Type: .net Framwork With FinchAPI
        //Author: Alex Hulst
        //Date Created: 12/3/2018
        //Last Modified: 12/9/2018
        // ************************************
        static Finch alma = new Finch();
        static void Main(string[] args)
        {
            DisplayWelcomeScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        static void DisplayMainMenu()
        {
            bool runApplication = true;
            string userMenuChoice;
            Finch alma = new Finch();

            while (runApplication)
            {
                DisplayHeader("Main Menu");

                //
                // display menu
                //
                Console.WriteLine("A) Avoid  Obstacles Finch will Avoid  an object)");
                Console.WriteLine("B) Avoid  the Tracking Light (Finch will Avoid  a bright light a flashlight while trying to move forwards)");
                Console.WriteLine("C) Avoid  Obstacles and the Tracking light");
                Console.WriteLine("Q) Quit");
                Console.WriteLine();
                Console.Write("Enter Menu Choice:");
                userMenuChoice = Console.ReadLine().ToUpper();

                //
                // process menu choice
                //
                switch (userMenuChoice)
                {
                    case "A":
                        advoidobstacles(alma);
                        break;
                    case "B":
                        AdvoidLight(alma);
                        break;
                    case "C":
                        AdvoidLightAndObsticales(alma);
                        break;
                    case "Q":
                        runApplication = false;
                        alma.disConnect();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a correct menu choice.");

                        DisplayContinuePrompt();
                        break;
                }
            }
        }
        private static void AdvoidLight(Finch Alma)
        {
            alma.connect();
            int light;
            int lightThreshold = 8;



            DisplayHeader("Finch flees before the spotlight");
            Console.WriteLine("Finch will Avoid  the spotlight (flashlight) for 10 seconds.");

            light = alma.getRightLightSensor();

            for (int i = 0; i < 17; i++)
            {
                alma.setMotors(100, 100);
                alma.setLED(0, 255, 0);
                alma.wait(500);

                //
                //avoids light
                //
                if ((lightThreshold + light) < alma.getRightLightSensor())
                {
                    alma.setMotors(255, 0);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                    alma.setMotors(255, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(1000);
                    alma.setMotors(255, 0);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                    alma.setMotors(255, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(1000);
                    alma.setMotors(0, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                }
                
            }
            alma.disConnect();
            DisplayContinuePrompt();
        }
        private static void AdvoidLightAndObsticales(Finch alma)
        {
            alma.connect();
            int light;
            int lightThreshold = 8;
            

            
            DisplayHeader("Finch flees before the spotlight");
            Console.WriteLine("Finch will Avoid the spotlight (flashlight) for 10 seconds. The Finch will also Avoid  Obsitacls");

            light = alma.getRightLightSensor();

            for (int i = 0; i < 17; i++)
            {
                alma.setMotors(100, 100);
                alma.setLED(0, 255, 0);
                alma.wait(500);
                
                //
                //avoid light
                //
                if ((lightThreshold + light) < alma.getRightLightSensor())
                {
                    alma.setMotors(255, 0);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                    alma.setMotors(255, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(1000);
                    alma.setMotors(255, 0);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                    alma.setMotors(255, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(1000);
                    alma.setMotors(0, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                }
                if (alma.isObstacleLeftSide())
                {
                    alma.setMotors(0, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                }

                else if (alma.isObstacleRightSide())
                {
                    alma.setMotors(255, 0);
                    alma.setLED(255, 0, 0);
                }
             }
            alma.disConnect();
                DisplayContinuePrompt();
        }

        private static void advoidobstacles(Finch alma)
        {
            alma.connect();
            

            
            DisplayHeader("Finch Avoids Obstacles.");
            Console.WriteLine("Finch will Avoid  objects for 10 seconds. While moving in a straight line");
            for (int i = 0; i < 17; i++)
            {
                //
                //avoid obstiacles
                //
            if (alma.isObstacleLeftSide())
                {
                    alma.setMotors(0, 255);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                }

                else if (alma.isObstacleRightSide())
                   {
                    alma.setMotors(255, 0);
                    alma.setLED(255, 0, 0);
                    alma.wait(500);
                   }
                else
                   {
                    alma.setMotors(100, 100);
                    alma.setLED(0, 255, 0);
                    alma.wait(500);
                    
                    DisplayHeader("Finch Avoids Obstacles.");
                    Console.WriteLine("Finch will Avoid  objects for 10 seconds. While moving in a straight line");
                    Console.WriteLine("No Obstacle Found");
                      
                    }
            }
            alma.disConnect();
            DisplayContinuePrompt();
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayHeader(string headText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(headText);
            Console.WriteLine();
        }

        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Sneaky Finch!");
            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine("Thank you for using the Sneaky Finch!");
            DisplayContinuePrompt();
        }

    }
}
