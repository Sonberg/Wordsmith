namespace Wordsmith.Core.Tests.Extensions.StringExtension
{
    using Xunit;
    using Wordsmith.Core.Extentions;

    public class StringExtension_ReverseWord
    {
        [Fact]
        public void EmptyString_ShouldReturn_EmptyString()
        {
            // arrange
            var value = string.Empty;

            // act
            var result = value.ReverseWord();

            // assert
            Assert.Equal(result, string.Empty);
        }

        [Fact]
        public void Word_ShouldReturn_ReversedWord()
        {
            // arrange
            var value = "Wordsmith";

            // act
            var result = value.ReverseWord();

            // assert
            Assert.Equal("htimsdroW", result);
        }
    }
}

