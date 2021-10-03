namespace Wordsmith.Core.Models
{
    public class WordTransformation
    {
        public Guid Id { get; set; }

        public string? Input { get; set; }

        public string? Result { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

