using System;
using TheCenter.Project;

namespace TheCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Project.Game MyGame = new Project.Game();
            MyGame.Setup(); //or similar
            //user input
            //validate input
            
            //myGame.go
            MyGame.Play();
            //game loop stuff here.
        }
    }
}
