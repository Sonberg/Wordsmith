namespace Wordsmith.Api.Tests.Validators
{
    using Wordsmith.Api.Validators;
    using Wordsmith.Api.Models;
    using Xunit;

    public class WordReversalRequestValidatorTests
    {
        [Fact]
        public void Null_ShouldReturn_False()
        {
            // arrange
            var validator = new WordReversalRequestValidator();
            var request = new WordReversalRequest { Input = null };

            // act
            var result = validator.Validate(request);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void EmptyString_ShouldReturn_False()
        {
            // arrange
            var validator = new WordReversalRequestValidator();
            var request = new WordReversalRequest { Input = string.Empty };

            // act
            var result = validator.Validate(request);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void SingleLetter_ShouldReturn_False()
        {
            // arrange
            var validator = new WordReversalRequestValidator();
            var request = new WordReversalRequest { Input = "a" };

            // act
            var result = validator.Validate(request);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void MultipleLetters_ShouldReturn_True()
        {
            // arrange
            var validator = new WordReversalRequestValidator();
            var request = new WordReversalRequest { Input = "ab" };

            // act
            var result = validator.Validate(request);

            // assert
            Assert.True(result.IsValid);
        }

    }
}