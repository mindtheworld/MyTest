namespace GildedRoseInn
{
    public sealed class ConjuredItem : AbstractItem
    {
        public ConjuredItem(int sellIn, int quality) : base("Conjured Mana Cake", sellIn, quality)
        {
        }


        /*  - At the end of each day our system lowers both values for every item
            - Once the sell by date has passed, Quality degrades twice as fast 
            - "Conjured" items degrade in Quality twice as fast as normal items   SellIn>0? (SellIn--, Quality-=2): (SellIn--, Quality-=4)           
         */
        protected override void UpdateQuality()
        {
            Quality = SellIn < 0 ? Quality - 4 : Quality - 2;
        }
       
    }
}