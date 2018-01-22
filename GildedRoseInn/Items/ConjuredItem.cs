namespace GildedRoseInn.Items
{
    public sealed class ConjuredItem : AbstractItem
    {
        #region Public Constructor

        public ConjuredItem(int sellIn, int quality) : base("Conjured Mana Cake", sellIn, quality)
        {
        }

        #endregion


        /*  - At the end of each day our system lowers both values for every item
            - Once the sell by date has passed, Quality degrades twice as fast 
            - "Conjured" items degrade in Quality twice as fast as normal items   SellIn>0? (SellIn--, Quality-=2): (SellIn--, Quality-=4)           
         */

        #region Protected Override Method

        protected override void UpdateQuality()
        {
            Quality = HasSellInPassed ? Quality - 4 * DefaultQualityModifier : Quality - 2 * DefaultQualityModifier;
        }

        #endregion
    }
}