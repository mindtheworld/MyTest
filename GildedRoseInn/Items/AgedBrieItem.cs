namespace GildedRoseInn.Items
{
    public sealed class AgedBrieItem : AbstractItem
    {
        #region Public Constructor

        public AgedBrieItem(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
        {
        }

        #endregion

        /*
         * - "Aged Brie" actually increases in Quality the older it gets (SellIn>0?Quality++:Quality+=2)          
         */

        #region Protected Override Method

        protected override void UpdateQuality()
        {
            Quality = HasSellInPassed ? Quality + 2 * DefaultQualityModifier : Quality + DefaultQualityModifier;
        }

        #endregion
    }
}