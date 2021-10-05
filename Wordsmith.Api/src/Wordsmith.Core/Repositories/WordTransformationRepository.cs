
namespace Wordsmith.Core.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Contexts;

    public interface IWordTransformationRepository
    {
        Task<List<WordTransformation>> GetAsync(CancellationToken cancellationToken = default);
        Task<WordTransformation> AddAsync(WordTransformation transformation, CancellationToken cancellationToken = default);
    }

    public class WordTransformationRepository : IWordTransformationRepository
    {
        public readonly IDatabaseContext _context;

        public WordTransformationRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public  Task<List<WordTransformation>> GetAsync(CancellationToken cancellationToken = default)
        {
            return _context.WordTransformations.AsQueryable().ToListAsync();
        }

        public async Task<WordTransformation> AddAsync(WordTransformation transformation, CancellationToken cancellationToken = default)
        {
            await _context.WordTransformations.AddAsync(transformation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return transformation;
        }
    }
}

