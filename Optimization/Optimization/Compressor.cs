using System;
using System.Text;

namespace Optimization
{
    public class Compressor
    {
        public string Compress(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length == 1) return $"{input}1";

            var output = Deflate(input);
            return output;
        }

        private static string Deflate(string input)
        {
            var total = 0;
            var output = new StringBuilder();
            for (var index = 0; index < input.Length; index++)
            {
                var currentCharacter = input[index].ToString();
                var nextCharacter = GetNextCharacter(input, index);
                total += 1;
                if (nextCharacter != currentCharacter)
                {
                    var compressedCouple = GetCompressedCouple(currentCharacter, total);
                    output.Append(compressedCouple);
                    total = 0;
                }
            }
            return output.ToString();
        }

        private static string GetNextCharacter(string input, int index)
        {
            return index + 1 < input.Length ? input[index + 1].ToString() : string.Empty;
        }

        private static string GetCompressedCouple(string character, int total)
        {
            return $"{character}{total}";
        }
    }
}
