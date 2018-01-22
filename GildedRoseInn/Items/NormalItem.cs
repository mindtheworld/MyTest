namespace GildedRoseInn.Items
{
    public class NormalItem : AbstractItem
    {
        #region Public Constructor

        public NormalItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        #endregion

        /*
        - At the end of each day our system lowers both values for every item. 
        - Once the sell by date has passed, Quality degrades twice as fast (SellIn<0?Quality-=2:Quality--)        
        */

        #region Protected Override Method

        protected override void UpdateQuality()
        {
            Quality = HasSellInPassed ? (Quality - 2 * DefaultQualityModifier) : (Quality - DefaultQualityModifier);
        }

        #endregion
    }
}