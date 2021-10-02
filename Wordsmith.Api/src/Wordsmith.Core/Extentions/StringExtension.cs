namespace Wordsmith.Core.Extentions
{
    public static class StringExtension
    {
        public static string ReverseWords(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return string.Join(" ", value.Split(" ").Select(ReverseWord));
        }

        private static string ReverseWord(string word)
        {
            var chars = word.ToCharArray();
            var reversed = chars.Reverse().ToArray();

            return new string(reversed);
        }

    }
}

