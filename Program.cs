using System;
using TheCenter.Project;

namespace TheCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Project.Game MyGame = new Project.Game();
            bool GameContinue = true;
            bool Flip = false;


            MyGame.Setup(); //or similar



            while (GameContinue)
            {
                if (Flip)
                {
                    // Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                //n,e,w, t, u, i, d

                Console.Clear();
                Console.Beep();
                Console.WriteLine("");
                Console.WriteLine($"You are in the {MyGame.CurrentRoom.Name}");
                Console.WriteLine("");
                Console.WriteLine($"{MyGame.CurrentRoom.Description}");
                Console.WriteLine("");
                Console.Write("What would you like to do?: ");
                string action = Console.ReadLine();

                if (action == "n" || action == "s" ||action == "e" ||action == "w")
                {
                    MyGame.Go(action);
                }

      

                //user input
                //validate input

                Flip = !Flip;
            }



            //myGame.go
            MyGame.Play();

            //game loop stuff here.
        }
    }
}
