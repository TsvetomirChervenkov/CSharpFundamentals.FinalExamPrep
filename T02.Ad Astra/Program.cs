using System;
using System.Text.RegularExpressions;

namespace T02.Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string validInput = @"([#|])(?<product>[A-Z-a-z\s]+)\1(?<date>[0-9]{2,}/[0-9]{2,}/[0-9]{2,})\1(?<calories>\d+)\1";
            
            MatchCollection matches = Regex.Matches(code, validInput);
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }
            int totalDays = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {totalDays} days!");
            foreach (Match match in matches)
            {
                Console.WriteLine($"Item: {match.Groups["product"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
