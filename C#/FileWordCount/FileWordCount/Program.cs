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

            if(words.Length < 5)
            {
                WriteLine("\n\nFile Should have minimum 5 words!!!");
            }

            var counts = words
                .GroupBy(w => w)
                .Select(g => new { Word = g.Key, Count = g.Count() })
                .ToList();

            WriteLine("\n\nPress any key ...");
            ReadKey();
        }
    }

}
