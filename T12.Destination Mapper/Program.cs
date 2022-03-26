using System;
using System.Text.RegularExpressions;

namespace T12.Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string validator = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})+\1";

            MatchCollection matches = Regex.Matches(input, validator);

            int lenght = 0;
            int counter = 0;
            string[] destinations = new string[matches.Count];

            foreach (Match match in matches)
            {
                lenght+= match.Groups["destination"].Value.Length;
                destinations[counter] = match.Groups["destination"].Value;
                counter++;

            }
            Console.WriteLine("Destinations: " + string.Join(", ", destinations));
            Console.WriteLine($"Travel Points: {lenght}");
        }
    }
}
