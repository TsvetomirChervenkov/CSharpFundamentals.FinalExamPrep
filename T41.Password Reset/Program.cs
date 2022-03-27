using System;
using System.Linq;

namespace T41.Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Done")
            {
                string[] cmdInfo = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdInfo[0];
                if (command == "TakeOdd")
                {
                    char[] symbols = text.Where((symbol,index) => index % 2 != 0).ToArray();
                    text = string.Join("", symbols);
                    Console.WriteLine(text);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(cmdInfo[1]);
                    int lenght = int.Parse(cmdInfo[2]);
                    text = text.Remove(index, lenght);
                    Console.WriteLine(text);
                }
                else if (command == "Substitute")
                {
                    string substring = cmdInfo[1];
                    string substitute = cmdInfo[2];
                    if (!text.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                    text = text.Replace(substring, substitute);
                    Console.WriteLine(text);
                }
            }
            Console.WriteLine($"Your password is: {text}");
        }
    }
}
