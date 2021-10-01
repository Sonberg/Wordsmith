
namespace Wordsmith.Core.Services
{
    using System.Linq;

    public interface IWordReversalService {
        string Transform(string value);
    }

    public class WordReversalService
    {
        public WordReversalService()
        {
        }

        public string Transform(string value) {
            return string.Join(" ", value.Split(" ").Select(Reverse));
        }

        private string Reverse(string word) {
            var chars = word.ToCharArray();
            var reversed = chars.Reverse().ToArray();

            return new string(reversed);
        }

    }
}

