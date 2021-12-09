using System;
using Xunit;

namespace FlakyTests
{
    public class FailingTests
    {
        int randomId; 
        
        public FailingTests()
        {
            var random = new Random(DateTime.Now.Millisecond);
            randomId = random.Next(1, 10);
            Console.WriteLine($"randomId: {randomId}");
        }
        
        [Fact]
        public void FlakyTest()
        {
            Assert.True(randomId % 7 != 0, $"Randomly failing test ({randomId}).");
        }

        [Fact]
        public void AnotherFlakyTest()
        {
            Assert.True(randomId % 7 != 0, $"Another randomly failing test ({randomId}).");
        }
    }
}
