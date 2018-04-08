using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FileRenamer
{
    class Program
    {
        private const string Pathname = @"C:\ebooks\";
        private const string WordSeperator = "-";

        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Pathname);
            Rename(files);
            Console.ReadKey();
        }

        private static void Rename(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var transformed = GetTitleCaseFilename(file);
                Directory.Move(file, $"{Pathname}{transformed}");
                Console.WriteLine($"{transformed}");
            }
        }

        private static string GetTitleCaseFilename(string file)
        {
            var filename = file.Replace(Pathname, string.Empty);
            var words = filename.Split(WordSeperator);
            var transformed = words
                .Select(ToTitleCase)
                .Aggregate((builder, word) => builder + " " + word);
            return transformed;
        }

        private static string ToTitleCase(string word)
        {
            var first = word[0].ToString().ToUpper();
            var remaining = word.Substring(1, word.Length - 1);
            return $"{first}{remaining}";
        }
    }
}
