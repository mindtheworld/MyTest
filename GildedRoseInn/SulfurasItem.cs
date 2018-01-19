namespace GildedRoseInn
{
    public sealed class SulfurasItem : NormalItem
    {
        public SulfurasItem() : base("Sulfuras, Hand of Ragnaros", 0, 80, isSpeical:true)
        {
        }


        /*- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality 
          - however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters. 
          - (Quality==80, SellIn==0)
              */

        public override void UpdateQuality()
        {
            //Both values stay the same, do nothing. 
        }
    }
}