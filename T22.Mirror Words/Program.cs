using System;
using System.Text.RegularExpressions;

namespace T22.Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string validator = @"([@#])(?<pair>[A-Za-z]{3,})\1\1(?<pair2>[A-Za-z]{3,})\1";
            MatchCollection matches = Regex.Matches(word, validator);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");

            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

            }
            string newstring = string.Empty;

            foreach (Match match in matches)
            {
                char[] reversed = match.Groups["pair2"].Value.ToCharArray();
                Array.Reverse(reversed);
                string newReversed = string.Join("", reversed);
                if (match.Groups["pair"].Value == newReversed)
                {
                    string oneMatch = $"{match.Groups["pair"].Value} <=> {match.Groups["pair2"].Value}, ";
                    newstring += string.Join(", ", oneMatch);
                }
            }
            if (newstring == string.Empty)
            {
                Console.WriteLine("No mirror words!");
                return;
            }
            newstring = newstring.TrimEnd(' ', ',');
            Console.WriteLine("The mirror words are:");
            Console.WriteLine(newstring);

        }
    }
}
