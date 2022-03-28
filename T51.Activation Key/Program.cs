using System;

namespace T51.Activation_Key
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Generate")
            {
                string[] info = cmd.Split(">>>");
                string command = info[0];
                if(command == "Contains")
                {
                    string substring = info[1];
                    if (input.Contains(substring))
                    {
                        Console.WriteLine($"{input} contains {substring}");
                        continue;
                    }
                    Console.WriteLine("Substring not found!");
                }
                else if (command == "Flip")
                {
                    if (info[1] == "Upper")
                    {
                        int index = int.Parse(info[2]);
                        int endIndex = int.Parse(info[3]);
                        string sub = input.Substring(index, endIndex-index ).ToUpper();
                        input = input.Remove(index, endIndex - index);
                        input = input.Insert(index, sub);
                        Console.WriteLine(input);
                    }
                    else if (info[1] == "Lower")
                    {
                        int index = int.Parse(info[2]);
                        int endIndex = int.Parse(info[3]);
                        string sub = input.Substring(index, endIndex - index).ToLower();
                        input = input.Remove(index, endIndex - index);
                        input = input.Insert(index, sub);
                        Console.WriteLine(input);
                    }

                }
                else if (command == "Slice")
                {
                    int index = int.Parse(info[1]);
                    int endIndex = int.Parse(info[2]);
                    input = input.Remove(index, endIndex - index);
                    Console.WriteLine(input);
                }
            }
            Console.WriteLine("Your activation key is: " + input);
        }
    }
}
