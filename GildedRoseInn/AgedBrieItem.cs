namespace GildedRoseInn
{
    public sealed class AgedBrieItem : AbstractItem
    {
        public AgedBrieItem(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
        {
        }

        /*- "Aged Brie" actually increases in Quality the older it gets (SellIn>0?Quality++:Quality+=2)
          - Just for clarification, an item can never have its Quality increase above 50, (Quality<=50)
          - The Quality of an item is never more than 50 (Quality<=50)
              */

        public override void UpdateQuality()
        {
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality + 2;
            }
            else
            {
                Quality = Quality + 1;
            }

            if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }
}