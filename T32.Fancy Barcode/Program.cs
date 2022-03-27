using System;
using System.Text.RegularExpressions;

namespace T02.Fancy_Barcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numBarcodes; i++)
            {
                string barcode = Console.ReadLine();
                string validator = @"^@[#]+(?<barcode>[A-Z][A-Za-z0-9]+[A-Z])[@][#]+$";
                Match match = Regex.Match(barcode, validator);
                if (match.Success)
                {
                    string groupName = match.Groups["barcode"].Value;
                    if (groupName.Length < 6)
                    {
                        Console.WriteLine("Invalid barcode");
                        continue;
                    }
                    string productGroup = string.Empty;
                    for (int character = 0; character < groupName.Length - 1; character++)
                    {
                        if (char.IsDigit(groupName[character]))
                        {
                            productGroup += groupName[character];
                        }
                    }
                    if (productGroup == string.Empty)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
