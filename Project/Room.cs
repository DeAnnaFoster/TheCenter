using System.Collections.Generic;

namespace TheCenter.Project
{
    public class Room : IRoom
    {
        public bool Special { get; set; }
        public List<Item> NeededItems { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Item> Items { get; set; } //see ctor

        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();

        public Room(string name, string description, bool special)
        {
            Items = new List<Item>();
            NeededItems = new List<Item>();
            Name = name;
            Description = description;
            Special = special;
        }

        public void UseItem(Item item)
        {

        }


    }
}