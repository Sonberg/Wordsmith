
namespace Wordsmith.Core.Repositories
{
    using Models;

    public interface IWordTransformationRepository
    {
        Task StoreAsync(WordTransformation transformation, CancellationToken cancellationToken);
    }

    public class WordTransformationRepository : IWordTransformationRepository
    {
        public WordTransformationRepository()
        {
        }

        public Task StoreAsync(WordTransformation transformation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

