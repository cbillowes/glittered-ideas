using System;

namespace Optimization
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Input for compression is required.");
                Console.ReadLine();
                return;
            }
            var compressor = new Compressor();
            var compressed = compressor.Compress(args[0]);
            Console.WriteLine(compressed);
            Console.ReadLine();
        }
    }
}
