namespace GildedRoseInn
{
    public class NormalItem : AbstractItem
    {
        public NormalItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        /*
        - At the end of each day our system lowers both values for every item(SellIn>=0 => SellIn--, Quality--)
        - Once the sell by date has passed, Quality degrades twice as fast (SellIn<0?Quality-=2:Quality--)
        - The Quality of an item is never negative (Quality>=0)    
        */

        public override void UpdateQuality()
        {
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality - 2;
            }
            else
            {
                Quality = Quality - 1;
            }

            if (Quality < 0)
            {
                Quality = 0;
            }
        }
    }
}