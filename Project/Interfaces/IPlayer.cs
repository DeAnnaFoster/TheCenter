using System.Collections.Generic;

namespace TheCenter.Project
{
    public interface IPlayer
    {
        int Score { get; set; }
        List<Item> Inventory { get; set; }

    }
}