using System;
using System.Collections.Generic;
using System.IO;
using Figgle;

namespace AgentGame
{
    internal class Program
    {
        private enum Mission
        {
            FirstMission,
            SecondMission
        }

        public static void Main(string[] args)
        {
            enableTyperEffect();
            Console.WriteLine("Hello Agent, welcome to the club!\n\nYou need to complete the missions for be free.");
            firstMission();
        }

        private static void firstMission()
        {
            Console.WriteLine("I'll be saying the instructions when you're ready for the mission.\n");
            Console.WriteLine("Use lowercase on all inputs!\n");
            Console.WriteLine("Press any key when you're ready!");
            Console.ReadKey();
            Console.Clear();
            firstMissionQuestions();
        }

        private static void firstMissionQuestions()
        {
            Console.WriteLine("Stole the security protocol of F-35’s!");
            Console.WriteLine(
                "You need to access the FTP (File Transfer Protocol) server of the United States Military.\n");
            Console.WriteLine("Firstly, you need to find the credentials of FTP server.");
            askQuestion(Mission.FirstMission, "\nWho is the president of the U.S.?", 1);
            askQuestion(Mission.FirstMission, "\nWhen was the United States founded (year)?", 2);
            askQuestion(Mission.FirstMission, "\nPlease enter the username:", 3);
            askQuestion(Mission.FirstMission, "\nPlease enter the password:", 4);
            showConnectingMessage();
            showAccessGranted();

            Console.WriteLine(FiggleFonts.Doh.Render("\nU.S.ARMY"));

            askQuestion(Mission.FirstMission,
                "Now, you have to access to the FTP server. You need to find the folder.\nHint: (use \"ls\" command)\n",
                5);
            Console.WriteLine("\nroot@mil.army:/$ ls \n\nlogs        secret\n");
            askQuestion(Mission.FirstMission,
                "You need to go inside the folder.\nHint: (use \"cd foldername\" command)\n", 6);
            Console.WriteLine("\nroot@mil.army:/$ cd secret\n");
            Console.WriteLine("root@mil.army:/secret$ \n");
            askQuestion(Mission.FirstMission,
                "You need to find the file.\nHint: (use \"ls\" command)\n", 7);
            Console.WriteLine("\nroot@mil.army:/secret$ ls \n\nusers.sql        f-35.txt\n");
            askQuestion(Mission.FirstMission, "Now, you need to read the file.\nHint: (use \"cat filename\" command)\n",
                8);
            Console.WriteLine("\nroot@mil.army:/secret$ cat f-35.txt\n");
            missionCompleted(Mission.FirstMission);
        }

        private static void secondMission()
        {
            Console.WriteLine("Well done! Welcome to the Second Mission!");
            Console.WriteLine("Your next mission is finding the location of the Israel agents");
            Console.WriteLine("Press any key when you're ready!");
            Console.ReadKey();
            Console.Clear();
            secondMissionQuestions();
        }

        private static void secondMissionQuestions()
        {
            Console.WriteLine("Infiltrate Israel's Satellite!");
            Console.WriteLine("You need to find the IP Address of Israel Space Agency Website!");
            askQuestion(Mission.SecondMission, "\nPlease enter the IP Address:", 1);
            askQuestion(Mission.SecondMission, "\nWho is the Chairman of the Israel Space Agency? (Full-name):", 2);
            askQuestion(Mission.SecondMission, "\nPlease enter the username:", 3);
            askQuestion(Mission.SecondMission, "\nPlease enter the password:", 4);
            showConnectingMessage();
            showAccessGranted();
            Console.WriteLine(FiggleFonts.Basic.Render("\nIsrael Satellite System"));
            askQuestion(Mission.SecondMission,
                "Now, you have to access to the Satellite System. You need to find the file.\n\nEnter the command:\n",
                5);
            Console.WriteLine("\nisaac@space.gov.il:/$ ls \n\nagents        government\n");
            askQuestion(Mission.SecondMission,
                "Enter the command:\n", 6);
            Console.WriteLine("\nisaac@space.gov.il:/$ cd agents\n");
            Console.WriteLine("isaac@space.gov.il:/agents \n");
            askQuestion(Mission.SecondMission,
                "Enter the command:\n", 7);
            Console.WriteLine("\nisaac@space.gov.il:/agents$ ls \n\nlocations.txt        cars.sql\n");
            askQuestion(Mission.SecondMission, "Enter the command:\n",
                8);
            Console.WriteLine("\nisaac@space.gov.il:/agents$ cat locations.txt\n");
            missionCompleted(Mission.SecondMission);
        }


        private static void askQuestion(Mission mission, String question, int questionNumber)
        {
            string answer = "";

            do
            {
                Console.WriteLine(question);
                answer = Console.ReadLine().ToLower();
            } while (!isAnswerValid(mission, answer, questionNumber));
        }

        private static bool isAnswerValid(Mission mission, string answer, int questionNumber)
        {
            bool isValid = false;
            if (!String.IsNullOrEmpty(answer))
            {
                if (mission == Mission.FirstMission)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            isValid = answer == "biden";
                            break;
                        case 2:
                            isValid = answer == "1776";
                            break;
                        case 3:
                            isValid = answer == "biden";
                            break;
                        case 4:
                            isValid = answer == "biden1776";
                            break;
                        case 5:
                            isValid = answer == "ls";
                            break;
                        case 6:
                            isValid = answer == "cd secret";
                            break;
                        case 7:
                            isValid = answer == "ls";
                            break;
                        case 8:
                            isValid = answer == "cat f-35.txt";
                            break;
                    }
                }
                else if (mission == Mission.SecondMission)
                {
                    switch (questionNumber)
                    {
                        case 1:
                            isValid = answer == "147.237.1.168";
                            break;
                        case 2:
                            isValid = answer == "isaac ben israel";
                            break;
                        case 3:
                            isValid = answer == "isaac";
                            break;
                        case 4:
                            isValid = answer == "israel";
                            break;
                        case 5:
                            isValid = answer == "ls";
                            break;
                        case 6:
                            isValid = answer == "cd agents";
                            break;
                        case 7:
                            isValid = answer == "ls";
                            break;
                        case 8:
                            isValid = answer == "cat locations.txt";
                            break;
                    }
                }
            }

            return isValid;
        }

        private static void enableTyperEffect()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypeWriter typewriter = new TypeWriter();
            Console.SetOut(typewriter);
        }

        private static void disableTyperEffect()
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        private static void missionCompleted(Mission mission)
        {
            Console.Clear();

            if (mission == Mission.FirstMission)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine(
                    FiggleFonts.Larry3d.Render("Mission Completed"));

                Console.ForegroundColor = ConsoleColor.Green;

                secondMission();
            }
            else if (mission == Mission.SecondMission)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                    FiggleFonts.Larry3d.Render("Game Completed"));
                
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(
                    FiggleFonts.Doom.Render("You are free :)"));
                
                System.Diagnostics.Process.Start("https://twitter.com/AdemOzcanTR");
            }
        }

        private static void showAccessGranted()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(
                FiggleFonts.SubZero.Render("Access Granted"));
            
        }

        private static void showConnectingMessage()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Connecting to the server %{0}...", i * 20);
            }

            Console.Clear();
        }
    }
}