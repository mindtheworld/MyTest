﻿namespace GildedRoseInn.Items
{
    public sealed class AgedBrieItem : AbstractItem
    {
        public AgedBrieItem(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
        {
        }

        /*
         * - "Aged Brie" actually increases in Quality the older it gets (SellIn>0?Quality++:Quality+=2)          
         */

        protected override void UpdateQuality()
        {
            Quality = HasSellInPassed ? Quality + 2 * DefaultQualityModifier : Quality + DefaultQualityModifier;
        }
    }
}