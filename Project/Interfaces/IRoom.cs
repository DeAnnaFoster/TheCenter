using System.Collections.Generic;

namespace TheCenter.Project
{
    public interface IRoom
    {
        bool Special { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        List<Item> Items { get; set; }

        void UseItem(Item item);

    }
}