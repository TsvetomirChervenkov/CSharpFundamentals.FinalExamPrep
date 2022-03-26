using System;
using System.Collections.Generic;
using System.Linq;

namespace T13._Plant_Discovery
{
    class Plant
    {
        public string Name { get; set; }
        public double Rarity { get; set; }
        public List<double> Rating { get; set; } = new List<double>();
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                   string[] info = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                double rarity = double.Parse(info[1]);
                if (plants.ContainsKey(name))
                {
                    plants[name].Rarity = rarity;
                    continue;
                }
                Plant newPlant = new Plant();
                {
                    newPlant.Name = name;
                    newPlant.Rarity = rarity;
                    newPlant.Rating = new List<double>();
                }
                plants.Add(name, newPlant);
            }
            string updateInfo = string.Empty;

            while ((updateInfo = Console.ReadLine()) != "Exhibition")
            {
                char[] splitBy = new char[] { ':' , '-', ' ' };
                string[] info = updateInfo.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
                string command = info[0];
                if (command == "Rate")
                {
                    string name = info[1];
                    double rating = double.Parse(info[2]);
                    if (!plants.ContainsKey(name))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    plants[name].Rating.Add(rating);
                }
                else if (command == "Update")
                {
                    string name = info[1];
                    double rarity = double.Parse(info[2]);
                    if (!plants.ContainsKey(name))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    plants[name].Rarity = rarity; 
                }
                else if (command == "Reset")
                {
                    string name = info[1];
                    if (!plants.ContainsKey(name))
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                    plants[name].Rating.Clear();
                }
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var item in plants)
            {
                double average = 0;
                if (item.Value.Rating.Count > 0)
                {
                    average = item.Value.Rating.Average();
                    
                }
                Console.WriteLine($"- {item.Value.Name}; Rarity: {item.Value.Rarity}; Rating: {average:f2}");
            }
        }
    }
}
