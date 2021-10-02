namespace Wordsmith.Core.Tests.Extensions
{
    using Wordsmith.Core.Extentions;
    using Xunit;

    public class StringExtension_ReverseSentence
    {
        [Fact]
        public void EmptyString_ShouldReturn_EmptyString()
        {
            // arrange
            var value = string.Empty;

            // act
            var result = value.ReverseSentence();

            // assert
            Assert.Equal(result, string.Empty);
        }

        [Fact]
        public void Word_ShouldReturn_ReversedWord()
        {
            // arrange
            var value = "The";

            // act
            var result = value.ReverseSentence();

            // assert
            Assert.Equal("ehT", result);
        }

 
        [Fact]
        public void Symbols_ShouldHave_SamePosition()
        {
            // arrange
            var value = "ice,";

            // act
            var result = value.ReverseSentence();

            // assert
            Assert.Equal("eci,", result);
        }

        [Fact]
        public void Sentance_ShouldReturn_ReversedSentance()
        {
            // arrange
            var value = "The red fox crosses the ice, intent on none of my business.";

            // act
            var result = value.ReverseSentence();

            // assert
            Assert.Equal("ehT der xof sessorc eht eci, tnetni no enon fo ym ssenisub.", result);
        }
    }
}

