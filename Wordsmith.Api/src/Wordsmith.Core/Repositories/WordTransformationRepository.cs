
namespace Wordsmith.Core.Repositories
{
    using Models;

    using Contexts;

    public interface IWordTransformationRepository
    {
        Task AddAsync(WordTransformation transformation, CancellationToken cancellationToken = default);
    }

    public class WordTransformationRepository : IWordTransformationRepository
    {
        public readonly IDatabaseContext _context;

        public WordTransformationRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(WordTransformation transformation, CancellationToken cancellationToken = default)
        {
            await _context.WordTransformations.AddAsync(transformation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

