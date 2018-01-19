using System;
using System.Collections.Generic;

namespace GildedRoseInn
{
    public class Inventory
    {
        private IList<NormalItem> Items { get; }

        public Inventory(IList<NormalItem> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];

                Console.WriteLine("Before:\t"+ currentItem);

                currentItem.UpdateQuality();

                Console.WriteLine("After:\t" + currentItem);
            }
        }
    }
}
