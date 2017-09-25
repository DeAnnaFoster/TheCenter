using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TheCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(75, 50);
            Project.Game MyGame = null;

            NewGame();
            
            void NewGame()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                MyGame = new Project.Game();
                MyGame.Setup();
                MyGame.Play();
            }
        }
    }
}
