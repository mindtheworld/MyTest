using GildedRoseInn;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Updating Inventory...");

            var items = new List<AbstractItem>
            {
                new NormalItem("+5 Dexterity Vest", 10, 20),
                new AgedBrieItem(2,0),
                new NormalItem("Elixir of the Mongoose", 5, 7),
                new SulfurasItem(),
                new BackstagePassesItem(15,20),
                new ConjuredItem(3, 6)
            };

            var myInventory= new Inventory(items);

            myInventory.UpdateQuality();

            System.Console.WriteLine("Updating Completed.");

            System.Console.ReadKey();

        }
    }
}
