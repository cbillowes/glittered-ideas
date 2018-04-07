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
            for (var i = 0; i < input.Length; i++)
            {
                var iteration = GetNextIteration(input, i, total);
                total = iteration.total;
                output.Append(iteration.output);
            }
            return output.ToString();
        }

        private static (string output, int total) GetNextIteration(string input, int index, int total)
        {
            var current = input[index].ToString();
            var next = GetNextCharacter(input, index);
            var output = string.Empty;
            total += 1;
            if (next != current)
            {
                output = $"{current}{total}";
                total = 0;
            }
            return (output, total);
        }

        private static string GetNextCharacter(string input, int index)
        {
            return index + 1 < input.Length ? input[index + 1].ToString() : string.Empty;
        }
    }
}
