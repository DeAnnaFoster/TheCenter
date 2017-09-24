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
            Inventory.Add((new Item("wristband", "wristband")));
        }

        public bool AddItem(Item item)
        {
            if (!Inventory.Contains(item))
            {
                Inventory.Add(item);
                return true;
            }

            return false;
        }

        public void IncreaseScore(int num)
        {
            Score += num;
        }
    }
}