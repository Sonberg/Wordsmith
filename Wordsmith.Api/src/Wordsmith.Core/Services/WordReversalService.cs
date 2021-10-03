
namespace Wordsmith.Core.Services
{
    using Models;
    using Extentions;
    using Repositories;


    public interface IWordReversalService
    {
        Task<string?> Transform(string? value, CancellationToken cancellationToken = default);
    }

    public class WordReversalService : IWordReversalService
    {
        private readonly IWordTransformationRepository _wordTransformationRepository;

        public WordReversalService(IWordTransformationRepository wordTransformationRepository)
        {
            _wordTransformationRepository = wordTransformationRepository;
        }

        public async Task<string?> Transform(string? value, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var reversed = value?.ReverseSentence();

            await _wordTransformationRepository.AddAsync(new WordTransformation
            {
                Input = value,
                Result = reversed,
                CreatedAt = DateTime.Now
            }, cancellationToken);

            return reversed;
        }

    }
}

