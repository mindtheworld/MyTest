using System;

namespace GildedRoseInn
{
    public class NormalItem : Item, IOperation
    {
        public NormalItem(string name, int sellIn, int quality, bool isSpeical = false)
        {
            var cleanedName = name.Trim();
            //Validate user input. 
            if (string.IsNullOrEmpty(cleanedName)) throw new ArgumentException("Name can't be empty");

            if (!isSpeical)
            {
                if (quality < 0 || quality > 50)
                    throw new ArgumentException("Quality can't be negative Or great than 50");
            }

            Name = cleanedName;
            SellIn = sellIn;
            Quality = quality;
        }


        /*  - At the end of each day our system lowers both values for every item(SellIn>=0 => SellIn--, Quality--)
            - Once the sell by date has passed, Quality degrades twice as fast (SellIn<0?Quality-=2:Quality--)
            - The Quality of an item is never negative (Quality>=0)    
              */

        public virtual void UpdateQuality()
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

        public override string ToString()
        {
            return $"Name: [{this.Name}], SellIn: [{this.SellIn}], Quality: [{this.Quality}]";
        }
    }
}