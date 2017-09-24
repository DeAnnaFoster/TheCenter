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




                Console.Clear();
                //Console.Beep(); //Where the Beep is that!? ;)
                Console.WriteLine("");
                MyGame.ylw();
                Console.WriteLine($"You are in the {MyGame.CurrentRoom.Name}");
                MyGame.grn();
                Console.WriteLine("");





                //It would be here that I need to check for Special Operations Etc
                MyGame.CurrentRoom.processDesc(MyGame.CurrentRoom.Description);

                Console.WriteLine("");
                Console.WriteLine("");





                bool repeatQuestion = true;

                while (repeatQuestion)
                {
                    MyGame.ylw();
                    Console.Write("What would you like to do?: ");
                    MyGame.grn();
                    string action = Console.ReadLine().ToLower();

                    if (action.StartsWith("t ") || action.StartsWith("u ") || action.StartsWith("i ") || action.StartsWith("d") || action.StartsWith("dr") || action.StartsWith("?")) //dr is for drop
                    {
                        int index = action.IndexOf(" ");
                        string actualItem = action.Substring(index + 1);

                        if (action.StartsWith("u "))
                        {
                            // Console.WriteLine($"{MyGame.CurrentRoom.Locked}");
                            // Console.ReadLine();

                            //works nicely as a trap
                            if (MyGame.CurrentRoom.Locked == true)
                            {


                                //maybe add timer here
                                MyGame.CurrentRoom.Locked = !MyGame.UseItem(actualItem);
                            }
                            else
                            {
                                MyGame.UseItem(actualItem);

                            }


                        }
                        else if (action.StartsWith("t "))
                        {
                            MyGame.TakeItem(actualItem);
                        }
                        else if (action.StartsWith("i"))//inventory & score
                        {
                            //MyGame.ShowInventory();
                        }
                        else if (action.StartsWith("dr "))//drop
                        {
                            //MyGame.RemoveItem(actualItem);
                        }
                        else if (action.StartsWith("? "))//Show Description - ???????
                        {
                            MyGame.CurrentRoom.processDesc(MyGame.CurrentRoom.Description);
                        }

                        repeatQuestion = true;
                    }
                    else if (action == "n" || action == "s" || action == "e" || action == "w" || action.StartsWith("dwn ") || action.StartsWith("up "))
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
