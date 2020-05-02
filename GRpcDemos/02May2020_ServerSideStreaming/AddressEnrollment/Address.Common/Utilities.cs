using System;
using System.Text;

namespace Address.Common
{

    public static class Utilities
    {
        static Random _random = new Random();
        static readonly string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
        static readonly string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
        const string _fullAddress = "Flat Number: {0}, {1} Apartments, Street: {2}, Hyderabad.";

        static public string GenerateName(int len)
        {
            StringBuilder name = new StringBuilder(50);

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

        static public string GenerateAddress()
        {
            return string.Format(_fullAddress, GetRandomValue(8, 999), GenerateName(GetRandomValue()), GenerateName(GetRandomValue()));
        }

        static public int GetRandomValue(int start = 8, int end = 17)
        {
            return _random.Next(start, end);
        }

        static public string[] EnrollmentTypes { get; } = { "General", "Bank", "Business", "Employment" };

    }

}
