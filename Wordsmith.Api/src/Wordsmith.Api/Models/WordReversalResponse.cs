namespace Wordsmith.Api.Models
{
    using Wordsmith.Core.Models;

    public class WordReversalResponse
    {
        public Guid Id { get; private set; }

        public string? Input { get; private set; }

        public string? Result { get; private set; }

        public DateTime? CreatedAt { get; private set; }

        public static WordReversalResponse From(WordTransformation transformation)
        {
            return new WordReversalResponse
            {
                Id = transformation.Id,
                Input = transformation.Input,
                Result = transformation.Result,
                CreatedAt = transformation.CreatedAt
            };
        }
    }
}
