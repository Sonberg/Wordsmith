
namespace Wordsmith.Core.Services
{
    using Models;
    using Extentions;
    using Repositories;


    public interface IWordReversalService
    {
        Task<WordTransformation?> Transform(string? value, CancellationToken cancellationToken = default);
    }

    public class WordReversalService : IWordReversalService
    {
        private readonly IWordTransformationRepository _wordTransformationRepository;

        public WordReversalService(IWordTransformationRepository wordTransformationRepository)
        {
            _wordTransformationRepository = wordTransformationRepository;
        }

        public async Task<WordTransformation?> Transform(string? value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            var reversed = value?.ReverseSentence();

            var transformation = await _wordTransformationRepository.AddAsync(new WordTransformation
            {
                Input = value,
                Result = reversed,
                CreatedAt = DateTime.Now
            }, cancellationToken);

            return transformation;
        }

    }
}

