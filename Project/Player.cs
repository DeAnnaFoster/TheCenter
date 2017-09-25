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
        }

        public bool AddItem(Item item)
        {
            bool FoundOne = false;

            if(item == null)
            {
                return false;
            }
            
            //add code here to only allow one jumpsuit
            if(item.Name.EndsWith("jumpsuit"))
            {         
                for(int j = 0; j < Inventory.Count; j++)
                {
                    if (Inventory[j].Name.EndsWith("jumpsuit"))
                    {
                        FoundOne = true;
                        break;
                    }
                }
            }

            if (!Inventory.Contains(item) && FoundOne == false)//FoundOne is used to flag a jumpsuit already there
            {
                Inventory.Add(item);
                return true;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("You already have one of those in your Inventory");
                Console.WriteLine("");
            }



            return false;
        }

        public void IncreaseScore(int num)
        {
            Score += num;
        }
    }
}