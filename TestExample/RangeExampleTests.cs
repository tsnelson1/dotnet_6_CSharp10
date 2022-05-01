using Xunit;

namespace TestExample
{
    public class RangeExampleTests
    {
        [Theory]
        [InlineData("This is a test.")]
        [InlineData("This is a second test.")]
        public void TestSubstringUsage(string testSample)
        {
            var firstRange = testSample.Substring(0, 4);
            var lastRange = testSample.Substring(testSample.Length-5, 4);
            Assert.Equal("This", firstRange); // validates the first 4 characters
            Assert.Equal("test", lastRange); // validates 4 last characters prior to the period
        }

        [Theory]
        [InlineData("This is a test.")]
        [InlineData("This is a second test.")]
        public void TestRangeUsage(string testSample)
        {
            var firstRange = testSample[0..4];
            var lastRange = testSample[^5..^1];
            Assert.Equal("This", firstRange); // validates the first 4 characters
            Assert.Equal("test", lastRange); // validates 4 last characters prior to the period
        }

        [Theory]
        [InlineData("This is a test.")]
        [InlineData("This is a second test.")]
        public void TestPatternMatchingUsage(string testSample)
        {
            var firstRange = testSample[0..4];
            var lastRange = testSample[^5..^1];
            Assert.Equal("This", firstRange); // validates the first 4 characters
            Assert.Equal("test", lastRange); // validates 4 last characters prior to the period
        }
    }
}