using System.Collections.Generic;
using System.Runtime.InteropServices;
using GildedRose.Console;
using GildedRoseInn;
using Xunit;
using Xunit.Abstractions;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        // check Xunit
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void TestTheTruthWithMoreValues(int value)
        {
            Assert.True(value > 0);
        }

        //- At the end of each day our system lowers both values for every item
        // SellIn>0? => SellIn--, Quality--
        [Fact]
        public void TestNormalItemWhenNotOverdue()
        {
            // arrange
            const string expectedName = "+5 Dexterity Vest";
            const int expectedSellIn = 9;
            const int expectedQuality = 19;

            var items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            };

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }

        // - Once the sell by date has passed, Quality degrades twice as fast 
        // SellIn<=0? => (SellIn--,Quality-=2):(SellIn--,Quality--)
        [Fact]
        public void TestNormalItemWhenOverdue()
        {
            // arrange
            const string expectedName = "+5 Dexterity Vest";
            const int expectedSellIn = -1;
            const int expectedQuality = 18;

            var items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20},
            };

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }

        // - The Quality of an item is never negative 
        // Quality>=0 always true
        [Theory]
        [InlineData("+5 Dexterity Vest", 10, 0)] //output: 9,0
        [InlineData("+5 Dexterity Vest", 0, 0)] //output: -1,0
        [InlineData("Elixir of the Mongoose", 5, 7)] //output: 4,6
        [InlineData("Elixir of the Mongoose", 0, 0)] //output: -1,0
        public void TestNormalItemWhenQualityIsZero(string name, int sellIn, int quality)
        {
            // arrange
            var expectedName = name;

            var items = new List<Item>
            {
                new Item {Name = name, SellIn = sellIn, Quality = quality}
            };

            var testInventory = new Inventory(items);
            var expectedSellIn = sellIn - 1;

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.True(itemToCheck.Quality >= 0);
        }

        //- "Aged Brie" actually increases in Quality the older it gets
        // SellIn>0? => SellIn--, Quality++
        [Fact]
        public void TestAgedBrieWhenNotOverdue()
        {
            // arrange
            const string expectedName = "Aged Brie";
            const int expectedSellIn = 1;
            const int expectedQuality = 1;

            var items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}
            };

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }

        //- "Aged Brie" actually increases in Quality the older it gets
        // SellIn<=0? => (SellIn--, Quality+=2)
        //* Note: Not been mentioned in the text. 
        [Fact]
        public void TestAgedBrieWhenOverdue()
        {
            // arrange
            const string expectedName = "Aged Brie";
            const int expectedSellIn = -1;
            const int expectedQuality = 4;

            var items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 2}
            };

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }


        // - The Quality of an item is never more than 50
        // an item can never have its Quality increase above 50
        // Quality<=50 always true
        [Theory]
        [InlineData(10, 50)] //output: 9,50
        [InlineData(0, 50)] //output: -1,50
        public void TestAgedBrieQualityAlwaysWithinFifty(int sellIn, int quality)
        {
            // arrange
            const string expectedName = "Aged Brie";

            var items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = sellIn, Quality = quality}
            };

            var expectedSellIn = sellIn - 1;
            const int expectedQuality = 50;

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }


        //- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        //- however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
        [Theory]
        [InlineData(0, 80)] //output: 0,80
        [InlineData(10, 80)] //output: -1,80
        [InlineData(-1, 80)] //output: -1,80
        public void TestSulfurasNeverAlters(int sellIn, int quality)
        {
            // arrange
            const string expectedName = "Sulfuras, Hand of Ragnaros";

            var items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality}
            };

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(sellIn, itemToCheck.SellIn);
            Assert.Equal(quality, itemToCheck.Quality);
        }


        //- "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; 
        //Quality increases by 2 when there are 10 days or less 
        //and by 3 when there are 5 days or less but Quality drops to 0 after the concert

        [Theory]
        [InlineData(15, 20)] //output: 14, 21 (+1)
        [InlineData(10, 20)] //output: 9, 22 (+2)
        [InlineData(5, 20)] //output: 4, 23 (-3)
        [InlineData(0, 20)] //output: -1,0 
        public void TestBackstagePassesWhenNotOverdue(int sellIn, int quality)
        {
            // arrange
            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";

            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = sellIn,
                    Quality = quality
                }
            };

            var testInventory = new Inventory(items);

            var expectedSellIn = sellIn - 1;

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);

            int expectedQuality;

            if (sellIn > 10)
            {
                expectedQuality = quality + 1;
              
            }
            else if (sellIn > 5 && sellIn <= 10)
            {
                expectedQuality = quality + 2;
               
            }
            else if (sellIn > 0 && sellIn <= 5)
            {
                expectedQuality = quality + 3;
                
            }
            else
            {
                expectedQuality = 0;
            }

            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }


        // - The Quality of an item is never more than 50
        // an item can never have its Quality increase above 50
        // Quality<=50 always true
        [Theory]
        [InlineData(10, 50)] //output: 9, 50
        [InlineData(5, 50)] //output: 4, 50
        public void TestBackstagePassesAlwaysWithinFifty(int sellIn, int quality)
        {
            // arrange
            const string expectedName = "Backstage passes to a TAFKAL80ETC concert";

            var items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality}
            };

            var expectedSellIn = sellIn - 1;
            const int expectedQuality = 50;

            var testInventory = new Inventory(items);

            // act
            testInventory.UpdateQuality();
            var itemToCheck = items[0];

            // assert
            Assert.Equal(expectedName, itemToCheck.Name);
            Assert.Equal(expectedSellIn, itemToCheck.SellIn);
            Assert.Equal(expectedQuality, itemToCheck.Quality);
        }



        //- "Conjured" items degrade in Quality twice as fast as normal items 
        // SellIn>0? (SellIn--, Quality-=2): (SellIn--, Quality-=4)
        //[Theory]
        //[InlineData(3, 6)] //output: 2, 4
        //[InlineData(0, 20)] //output: -1, 16
        //public void TestConjuredManaCake(int sellIn, int quality)
        //{
        //    // arrange
        //    const string expectedName = "Conjured Mana Cake";

        //    var items = new List<Item>
        //    {
        //        new Item {Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality}
        //    };

        //    var expectedSellin = sellIn - 1;

        //    var testInventory = new Inventory(items);

        //    // act
        //    testInventory.UpdateQuality();
        //    var itemToCheck = items[0];

        //    // assert
        //    Assert.Equal(expectedName, itemToCheck.Name);
        //    Assert.Equal(expectedSellin, itemToCheck.SellIn);

        //    if (sellIn > 0)
        //    {
        //        var expectedQuality = quality - 2;
        //        Assert.Equal(expectedQuality, itemToCheck.Quality);
        //    }
        //    else
        //    {
        //        var expectedQuality = quality - 4;
        //        Assert.Equal(expectedQuality, itemToCheck.Quality);
        //    }
        //}
    }
}