namespace Wordsmith.Core.Extentions
{
    public static class StringExtension
    {
        public static IEnumerable<string> SplitOnSymbols(this string s)
        {
            int index;
            int start = 0;

            int getNextIndex()
            {
                var symbols = s.Where(x => !char.IsLetter(x)).ToArray();

                return symbols.Any() ? s.IndexOfAny(symbols, start) : -1;
            }

            while ((index = getNextIndex()) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);

                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }

        public static string ReverseSentence(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var words = value.SplitOnSymbols().Select(ReverseWord);
            var result = string.Join("", words);

            return result;
        }

        public static string ReverseWord(this string word)
        {
            var characters = word.ToCharArray();
            var reversed = characters.Reverse().ToArray();

            return new string(reversed);
        }
    }
}

