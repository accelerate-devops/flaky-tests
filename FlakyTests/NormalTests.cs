using System;
using Xunit;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using SystemUnderTest;

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
            Thread.Sleep(milliseconds);
        }

        [Theory]
        [InlineData(0, 5, 5)]
        [InlineData(100, 100, 200)]
        [InlineData(-5, 5, 0)]
        public void AddTest(int a, int b, int result)
        {
            var sut = new Sut();
            Assert.Equal(result, sut.Add(a, b));
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void RandomTests(int i, string s)
        {
            var sut = new Sut();
            sut.Random(i, s);
        }

        public class TestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                for (int i = 0; i < 75; i++)
                {
                    yield return new object[] { i, $"Test {i}" };
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
