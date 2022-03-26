using System;

namespace T11.World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string travel = Console.ReadLine();
            string plan = string.Empty;
            while ((plan = Console.ReadLine()) != "Travel")
            {
                string[] input = plan.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                if (command == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    string newStop = input[2];
                    if(index > plan.Length)
                    {
                        Console.WriteLine(travel);
                        continue;
                    }
                    travel = travel.Insert(index, newStop);
                    Console.WriteLine(travel);
                }
                else if (command == "Remove Stop")
                {
                    int  startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    if ((startIndex < 0 || startIndex >= travel.Length) || (endIndex < 0 || endIndex+1 > travel.Length))
                    {
                        Console.WriteLine(travel);
                        continue;
                    }
                    travel = travel.Remove(startIndex, endIndex-startIndex+1);
                    Console.WriteLine(travel);
                }
                else if (command == "Switch")
                {
                    string old = input[1];
                    string newString = input[2];
                    if (travel.Contains(old))
                    {
                        travel = travel.Replace(old, newString);
                        Console.WriteLine(travel);
                        continue;
                    }
                    Console.WriteLine(travel);
                }
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {travel}");
        }
    }
}
