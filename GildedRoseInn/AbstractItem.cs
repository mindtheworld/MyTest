using System;

namespace GildedRoseInn
{
    public abstract class AbstractItem : Item, IOperation
    {
        protected AbstractItem(string name, int sellIn, int quality, bool isSpeical = false)
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

        public abstract void UpdateQuality();

        public override string ToString()
        {
            return $"Name: [{this.Name}], SellIn: [{this.SellIn}], Quality: [{this.Quality}]";
        }
    }
}