using System;
using System.Collections.Generic;

namespace TheCenter.Project
{
    public class Room : IRoom
    {
        public bool Special { get; set; }
        public bool Locked { get; set; }
        public Item SpecialItem { get; set; }
        public List<Item> NeededItems { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Item> Items { get; set; } //see ctor

        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();

        public List<string> usedItems { get; set; }

        public Room(string name, string description, bool special, Item specialitem, bool locked)
        {
            Items = new List<Item>();
            NeededItems = new List<Item>();
            usedItems = new List<string>();
            Name = name;
            Description = description;
            Special = special;
            Locked = locked;

            if (specialitem.Name != "")
            {
                SpecialItem = specialitem;
            }

        }

        public bool UseItem(Item item)
        {
            Console.Clear();
            processDesc(item.Description);
            Console.WriteLine("");

            return true;
        }

        public void processDesc(string desc)
        {
            foreach (char ch in desc)
            {
                if (ch == '(')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                if (ch == ')')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    continue;
                }

                Console.Write(ch);
            }
        }
    }
}