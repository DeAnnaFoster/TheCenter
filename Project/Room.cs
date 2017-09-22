using System.Collections.Generic;

namespace TheCenter.Project
{
    public class Room : IRoom
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Item> Items { get; set; } //see ctor

        public Dictionary<string, Room> Exits = new Dictionary<string, Room>();


        public Room(string name, string description)
        {
            Items = new List<Item>();
            Name = name;
            Description = description;
        }

        public void UseItem(Item item)
        {

        }


    }
}