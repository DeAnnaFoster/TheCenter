using System;
using System.Media;
using System.Timers;
using TheCenter.Project;

namespace TheCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(75, 50);
            Console.ForegroundColor = ConsoleColor.Green;

            // Console.BackgroundColor = ConsoleColor.Black;
            // Console.ForegroundColor = ConsoleColor.DarkGreen;

            // System.ConsoleColor blu = Console.ForegroundColor = ConsoleColor.Blue;
            // System.ConsoleColor grn = Console.ForegroundColor = ConsoleColor.Green;
            // System.ConsoleColor gry = Console.ForegroundColor = ConsoleColor.Gray;

            Project.Game MyGame = new Project.Game();
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();


            // MyGame.processDesc("This is a (t)est \r\nof the \r\nemergency (b)roadcast system.");
            // Console.ReadLine();


            bool GameContinue = true;
            MyGame.Setup(); //or similar

            while (GameContinue)
            {
                //n, e, w, t, u, i, d, h?

                Console.Clear();
                Console.Beep();
                Console.WriteLine("");
                Console.WriteLine($"You are in the {MyGame.CurrentRoom.Name}");
                Console.WriteLine("");
                MyGame.processDesc(MyGame.CurrentRoom.Description);
                //Console.WriteLine($"{MyGame.processDesc(MyGame.CurrentRoom.Description)}");

                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("What would you like to do?: ");
                string action = Console.ReadLine().ToLower();

                if (action == "n" || action == "s" || action == "e" || action == "w")
                {
                    MyGame.Go(action);
                }

                //user input
                //validate input


                using (SoundPlayer player = new SoundPlayer("C:\\bass.wav"))
                {
                    // Use PlaySync to load and then play the sound.
                    // ... The program will pause until the sound is complete.
                    player.PlaySync();
                }

            }


            //myGame.go
            MyGame.Play();

            //game loop stuff here.


        }


    }
}
