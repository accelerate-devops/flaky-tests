using System;
using Xunit;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

namespace FlakyTests
{
    public class NormalTests
    {
        [Theory]
        [InlineData(40)]
        [InlineData(60)]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(400)]
        [InlineData(500)]
        [InlineData(1000)]
        [InlineData(2000)]
        public void LongRunningTest(int milliseconds)
        {
            Thread.Sleep(400);
        }

        [Fact]
        public void FlakyTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var next = random.Next(10);
            Assert.True(next % 3 != 0, "Randomly failing test.");
        }

        [Fact]
        public void AnotherFlakyTest()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var next = random.Next(10);
            Assert.True(next % 3 != 0, "Another randomly failing test.");
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void RandomTests(string s)
        {
            Console.WriteLine(s);
        }

        public class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                for (int i = 0; i < 75; i++)
                {
                    yield return new object[] { $"Test {i}" };
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
