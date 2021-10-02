
namespace Wordsmith.Core.Repositories
{
    using Models;

    public interface IWordTransformationRepository
    {
        Task AddAsync(WordTransformation transformation, CancellationToken? cancellationToken);
    }

    public class WordTransformationRepository : IWordTransformationRepository
    {
        public WordTransformationRepository()
        {
        }

        public async Task AddAsync(WordTransformation transformation, CancellationToken? cancellationToken)
        {
            // throw new NotImplementedException();
        }
    }
}

