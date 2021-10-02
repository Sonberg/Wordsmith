namespace Wordsmith.Core.Tests.Extensions.StringExtension
{
    using Xunit;
    using Wordsmith.Core.Extentions;

    public class StringExtension_SplitOnSymbols
    {
        [Fact]
        public void OnlyLetters()
        {
            // arrange
            var value = "Wordsmith";

            // act
            var result = value.SplitOnSymbols();

            // assert
            Assert.Equal(new[] { "Wordsmith" }, result);
        }

        [Fact]
        public void LettersAndNumbers()
        {
            // arrange
            var value = "Wordsmith24";

            // act
            var result = value.SplitOnSymbols();

            // assert
            Assert.Equal(new[] { "Wordsmith", "2", "4" }, result);
        }

        [Fact]
        public void NumberBetweenLetters()
        {
            // arrange
            var value = "Word1smith";

            // act
            var result = value.SplitOnSymbols();

            // assert
            Assert.Equal(new[] { "Word", "1", "smith" }, result);
        }

        [Fact]
        public void Words()
        {
            // arrange
            var value = "Lorem Ipsum";

            // act
            var result = value.SplitOnSymbols();

            // assert
            Assert.Equal(new[] { "Lorem", " ", "Ipsum" }, result);
        }

        [Fact]
        public void Sentance()
        {
            // arrange
            var value = "The red fox crosses the ice, intent on none of my business.";
            

            // act
            var result = value.SplitOnSymbols();

            // assert
            var expected = new[] {
                "The",
                " ",
                "red",
                " ",
                "fox",
                " ",
                "crosses",
                " ",
                "the",
                " ",
                "ice",
                ",",
                " ",
                "intent",
                " ",
                "on",
                " ",
                "none",
                " ",
                "of",
                " ",
                "my",
                " ",
                "business",
                "."
            };

            Assert.Equal(expected, result);
        }
    }
}

