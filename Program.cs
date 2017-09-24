using System;
using System.Diagnostics;

namespace TheCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(75, 50);
            Console.ForegroundColor = ConsoleColor.Green;
            Project.Game MyGame = new Project.Game();

            bool GameContinue = true;
            MyGame.Setup();

            while (GameContinue)
            {
                //n, s, e, w,  t, u, i, d, h?

                Console.Clear();
                //Console.Beep();
                Console.WriteLine("");
                MyGame.ylw();
                Console.WriteLine($"You are in the {MyGame.CurrentRoom.Name}");
                MyGame.grn();
                Console.WriteLine("");
                //MyGame.processDesc(MyGame.CurrentRoom.Description);
                MyGame.CurrentRoom.processDesc(MyGame.CurrentRoom.Description);

                //Console.WriteLine($"{MyGame.processDesc(MyGame.CurrentRoom.Description)}");

                Console.WriteLine("");
                Console.WriteLine("");
                bool repeatQuestion = true;

                while (repeatQuestion)
                {
                    Console.Write("What would you like to do?: ");
                    string action = Console.ReadLine().ToLower();

                    // int index = action.IndexOf(" ");
                    // string actualItem = action.Substring(index + 1);

                    if (action.StartsWith("t ") || action.StartsWith("u ") || action.StartsWith("i ") || action.StartsWith("de") || action.StartsWith("dr") || action.StartsWith("h")) //dr is for drop
                    {

                        if (action.StartsWith("u "))
                        {
                            // Console.WriteLine("such a user");
                            // Console.ReadLine();

                            int index = action.IndexOf(" ");
                            string actualItem = action.Substring(index + 1);

                            // Console.WriteLine("");
                            // Console.WriteLine($"You are using the '{actualItem}'");
                            // Console.WriteLine("");

                            //works nicely as a trap
                            if (MyGame.CurrentRoom.Locked == true)
                            {
                                //maybe add timer here
                                MyGame.CurrentRoom.Locked = !MyGame.UseItem(actualItem);
                            }

                        }
                        else if (action.StartsWith("t "))
                        {
                            int index = action.IndexOf(" ");

                            // Console.WriteLine($"Index found was {index}");
                            // Console.ReadLine();

                            string actualItem = action.Substring(index + 1);

                            // Console.WriteLine("");
                            // Console.WriteLine($"You are taking the '{actualItem}'");
                            // Console.WriteLine("");
                            // Console.ReadLine();
                            MyGame.TakeItem(actualItem);

                        }

                        repeatQuestion = true;
                    }
                    else if (action == "n" || action == "s" || action == "e" || action == "w")
                    {
                        // if(MyGame.CurrentRoom.Exits.ContainsKey(action))
                        // {
                        //     Console.WriteLine("Woohoo");
                        // }
                        // else
                        // {
                        //     Console.WriteLine("THat is not possible");
                        // }

                        // Console.WriteLine($"cURRENTroOM LOCKED ISs {MyGame.CurrentRoom.Locked}");
                        // Console.WriteLine($"Action now for KeyCheck is {action}");
                        // Console.WriteLine($"ContainsKey is{MyGame.CurrentRoom.Exits.ContainsKey(action)}");


                        if (MyGame.CurrentRoom.Locked == false && MyGame.CurrentRoom.Exits.ContainsKey(action))
                        {
                            MyGame.Go(action);
                            repeatQuestion = false;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("That is not possible right now.");
                            Console.WriteLine("");
                            repeatQuestion = true;

                        }

                    }
                    else
                    {
                        repeatQuestion = true;
                    }
                }


                //user input
                //validate input

            }

            //myGame.go
            MyGame.Play();

            //game loop stuff here.


        }


    }
}
