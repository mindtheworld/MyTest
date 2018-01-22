using System;
using System.Collections.Generic;
using GildedRoseInn.Items;

namespace GildedRoseInn
{
    public class Inventory
    {
        #region Private Property

        private IList<AbstractItem> Items { get; }

        #endregion

        #region Public Constructor

        public Inventory(IList<AbstractItem> items)
        {
            Items = items;
        }

        #endregion

        #region Public Method

        public void UpdateQuality()
        {
            foreach (var currentItem in Items)
            {
                Console.WriteLine("Before:\t" + currentItem);

                currentItem.Update();

                Console.WriteLine("After:\t" + currentItem);
            }
        }

        #endregion
    }
}