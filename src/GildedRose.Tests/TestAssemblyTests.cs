using System.Collections.Generic;
using GildedRose.Console;
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


        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void TestTheTruthWithMoreValues(int value)
        {
            Assert.True(value > 0);
        }


        //- All items have a SellIn value which denotes the number of days we have to sell the item
        //- All items have a Quality value which denotes how valuable the item is
        //- At the end of each day our system lowers both values for every item

        [Fact]
        public void TestPlusFiveDexterityVest()
        {
            // arrange
            const string expectedName = "+5 Dexterity Vest";
            const int expectedSellin = 9;
            const int expectedQuality = 19;

            var app = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},

                }

            };

            // act
            app.UpdateQuality();

            // assert
            var itemToCheck = app.Items[0];
            Assert.Equal(itemToCheck.Name, expectedName);
            Assert.Equal(itemToCheck.SellIn, expectedSellin);
            Assert.Equal(itemToCheck.Quality, expectedQuality);
        }


    }
}