using Xunit;

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
            Assert.True(value>0);
        }
    }
}