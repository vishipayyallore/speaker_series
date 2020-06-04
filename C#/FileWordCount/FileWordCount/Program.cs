using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace FileWordCount
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ".\\Data\\Sample1.txt";

            var fileContent = File.ReadAllText(filePath);
            WriteLine($"File Content: {fileContent}");

            var words = fileContent.Replace("\r\n"," ").Split(" ");

            var counts = words
                .GroupBy(w => w)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .ToList();

            WriteLine("\n\nPress any key ...");
            ReadKey();
        }
    }

}
