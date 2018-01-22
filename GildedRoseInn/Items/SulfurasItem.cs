namespace GildedRoseInn.Items
{
    public sealed class SulfurasItem : AbstractItem
    {
        public SulfurasItem() : base("Sulfuras, Hand of Ragnaros", 0, 80, isSpeical:true)
        {
        }


        /*- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality 
          - however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters. 
          - (Quality==80, SellIn==0)
              */


        protected override void UpdateSellIn()
        {
            //do nothing.
        }

        protected override void UpdateQuality()
        {
            //do nothing.
        }

        protected override void CheckQualityRange()
        {
            //Quality == 80
            //do nothing == no check. 
        }

    }
}