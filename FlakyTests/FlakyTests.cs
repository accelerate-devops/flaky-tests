using System;
using Xunit;

namespace FlakyTests
{
    public class FailingTests
    {
        [Fact]
        public void FlakyTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var next = random.Next(8);
            Assert.True(next % 3 != 0, $"Randomly failing test ({next}).");
        }

        [Fact]
        public void AnotherFlakyTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var next = random.Next(8);
            Assert.True(next % 3 != 0, $"Another randomly failing test ({next}).");
        }
    }
}
