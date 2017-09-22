using System.Collections.Generic;

namespace TheCenter.Project
{
    public class Player : IPlayer
    {
        public int Score { get; set; }
        
        public List<Item> Inventory { get; set; }

        public Player()
        {
            Score = 0;
            Inventory = new List<Item>();
        }
    }
}