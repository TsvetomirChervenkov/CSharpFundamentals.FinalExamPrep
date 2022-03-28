using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace T52.Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string validator = @"(\:{2,}|\*{2,})(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection matches = Regex.Matches(text, validator);
            List<int> numbers = new List<int>();
            
            AddAllNumbers(numbers, text);

            BigInteger coolTreshHold = MultiplyAllNumbers(numbers);
            
            Console.WriteLine("Cool threshold: " + coolTreshHold);
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            
            foreach (Match match in matches)
            {
                int coolness = 0;
                for (int i = 0; i < match.Groups["emoji"].Value.Length; i++)
                {
                    if (char.IsLetter(match.Groups["emoji"].Value[i]))
                    {
                        coolness += match.Groups["emoji"].Value[i];
                    }
                    
                }
                if (coolness >= coolTreshHold)
                {
                    Console.WriteLine(match);
                }
            }


        }
        static void AddAllNumbers(List<int> numbers, string text)
        {

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    int curr = text[i] - '0';
                    numbers.Add(curr);
                }
            }
        }
        static BigInteger MultiplyAllNumbers(List<int> numbers)
        {
            BigInteger bigInt = 1;
            foreach (var num in numbers)
            {
                
                bigInt *= num;
            }
            return bigInt;
        }
    }
}
