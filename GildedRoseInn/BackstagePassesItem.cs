namespace GildedRoseInn
{
    public sealed class BackstagePassesItem : AbstractItem
    {
        public BackstagePassesItem(int sellIn, int quality) : base("Backstage passes to a TAFKAL80ETC concert", sellIn,
            quality)
        {
        }


        /*- "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; (Quality++)
          - Quality increases by 2 when there are 10 days or less. (Quality+=2)
          - and by 3 when there are 5 days or less (Quality+=3)
          - but Quality drops to 0 after the concert (SellIn<=0 => Quality=0)        
         */

        protected override void UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else if (SellIn > 0 && SellIn <= 5)
            {
                Quality = Quality + 3;
            }
            else if (SellIn > 5 && SellIn <= 10)
            {
                Quality = Quality + 2;
            }
            else
            {
                Quality = Quality + 1;
            }
        }
    }
}