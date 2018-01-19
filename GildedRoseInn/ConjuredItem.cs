namespace GildedRoseInn
{
    public sealed class ConjuredItem : NormalItem
    {
        public ConjuredItem(int sellIn, int quality) : base("Conjured Mana Cake", sellIn, quality)
        {
        }


        /*  - At the end of each day our system lowers both values for every item
            - Once the sell by date has passed, Quality degrades twice as fast 
            - "Conjured" items degrade in Quality twice as fast as normal items   SellIn>0? (SellIn--, Quality-=2): (SellIn--, Quality-=4)           
            - The Quality of an item is never negative (Quality>=0)    
              */

        public override void UpdateQuality()
        {
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality - 4;
            }
            else
            {
                Quality = Quality - 2;
            }

            if (Quality < 0)
            {
                Quality = 0;
            }
        }
    }
}