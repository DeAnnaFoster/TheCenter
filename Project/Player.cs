using System;
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
            //Inventory.Add((new Item("wristband", "wristband")));
        }

        public bool AddItem(Item item)
        {
            if (!Inventory.Contains(item))
            {
                Inventory.Add(item);
                return true;
            }
            else
            {
                Console.WriteLine("You already have one of those in your Inventory");
            }

            return false;
        }

        public void IncreaseScore(int num)
        {
            Score += num;
        }
    }
}