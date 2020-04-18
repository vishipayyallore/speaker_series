using System;
using System.Text;

namespace RandomNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for(var iCtr=0; iCtr <100; iCtr++)
            {
                Console.WriteLine($"Name: {GenerateName(10)}");
            }

            Console.ReadKey();
        }

        public static string GenerateName(int len)
        {
            StringBuilder name = new StringBuilder(50);
            Random random = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };

            
            name.Append(consonants[random.Next(consonants.Length)].ToUpper());
            name.Append(vowels[random.Next(vowels.Length)]);
            int b = 2; 
            while (b < len)
            {
                name.Append(consonants[random.Next(consonants.Length)]);
                b++;
                name.Append(vowels[random.Next(vowels.Length)]);
                b++;
            }

            return name.ToString();
        }

    }
}
