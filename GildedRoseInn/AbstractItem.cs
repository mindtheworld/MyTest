using System;
using GildedRoseInn.Properties;

namespace GildedRoseInn
{
    public abstract class AbstractItem : Item, IOperation
    {
        private int QualityMin { get; }

        private int QualityMax { get; }

        protected AbstractItem(string name, int sellIn, int quality, bool isSpeical = false)
        {
            QualityMin = Settings.Default.QualityMin;
            QualityMax = Settings.Default.QualityMax;

            //Clean up this input before validation.
            var cleanedName = name.Trim();

            //Validate user input. 
            if (string.IsNullOrEmpty(cleanedName)) throw new ArgumentException("Name can't be empty");

            //Check if it's speical type of item. 
            if (!isSpeical)
            {
                if (quality < QualityMin || quality > QualityMax)
                    throw new ArgumentException("Quality can't be negative Or great than 50");
            }

            Name = cleanedName;
            SellIn = sellIn;
            Quality = quality;
        }

        protected virtual void UpdateSellIn()
        {
            SellIn--;
        }

        protected abstract void UpdateQuality();


        //- The Quality of an item is never negative(Quality>=0)
        //- Just for clarification, an item can never have its Quality increase above 50, (Quality<=50)
        //- The Quality of an item is never more than 50 (Quality<=50)

        protected virtual void CheckQualityRange()
        {
            if (Quality < QualityMin)
            {
                Quality = QualityMin;
            }

            if (Quality > QualityMax)
            {
                Quality = QualityMax;
            }
        }


        public void Update()
        {
            UpdateSellIn();

            UpdateQuality();

            CheckQualityRange();
        }

        public override string ToString()
        {
            return $"Name: [{this.Name}], SellIn: [{this.SellIn}], Quality: [{this.Quality}]";
        }
    }
}