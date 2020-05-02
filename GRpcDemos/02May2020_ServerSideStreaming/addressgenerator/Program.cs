using System;
using System.Text;

using static System.Console;

namespace addressgenerator
{
    class Program
    {
        static Random _random = new Random();
        const string _fullAddress = "Flat Number: {0}, {1} Apartments, Street: {2}, Hyderabad.";
        static readonly string[] _enrollmentStatus = { "Pending", "In Progress", "Rejected", "Enrolled" };

        static void Main(string[] args)
        {

            WriteLine($"{_enrollmentStatus[GetRandomValue(1, 4)]}");
            WriteLine($"{_enrollmentStatus[GetRandomValue(1, 4)]}");
            WriteLine($"{_enrollmentStatus[GetRandomValue(1, 4)]}");
            WriteLine($"{_enrollmentStatus[GetRandomValue(1, 4)]}");
            WriteLine($"{_enrollmentStatus[GetRandomValue(1, 4)]}");
            WriteLine($"{_enrollmentStatus[GetRandomValue(1, 4)]}");

            // WriteLine($"{GetRandomValue(8,999)} {GenerateName(GetRandomValue())} {GenerateName(GetRandomValue())}");
            var addr = string.Format(_fullAddress, GetRandomValue(8, 999), GenerateName(GetRandomValue()), GenerateName(GetRandomValue()));
            WriteLine($"Address: {addr}");

            WriteLine("\n\nPress any key ...");
            ReadKey();
        }

        static private string GenerateName(int len)
        {
            StringBuilder name = new StringBuilder(50);

            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };


            name.Append(consonants[_random.Next(consonants.Length)].ToUpper());
            name.Append(vowels[_random.Next(vowels.Length)]);
            int b = 2;
            while (b < len)
            {
                name.Append(consonants[_random.Next(consonants.Length)]);
                b++;
                name.Append(vowels[_random.Next(vowels.Length)]);
                b++;
            }

            return name.ToString();
        }

        static private int GetRandomValue(int start = 8, int end = 17)
        {
            return _random.Next(start, end);
        }
    }
}
