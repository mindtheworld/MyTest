using System;
using System.Collections.Generic;

namespace GildedRoseInn
{
    public class Inventory
    {
        private IList<AbstractItem> Items { get; }

        public Inventory(IList<AbstractItem> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var currentItem in Items)
            {
                Console.WriteLine("Before:\t"+ currentItem);

                currentItem.Update();

                Console.WriteLine("After:\t" + currentItem);
            }
        }
    }
}
