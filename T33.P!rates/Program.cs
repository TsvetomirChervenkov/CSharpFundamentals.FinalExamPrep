using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.P_rates
{
    class Town
    {
        public Town(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Town> listOfTowns = new List<Town>();

            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "Sail")
            {
                string[] commandArgs = commands.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = commandArgs[0];
                int population = int.Parse(commandArgs[1]);
                int gold = int.Parse(commandArgs[2]);
                var town = listOfTowns.FirstOrDefault(x=>x.Name == cityName);
                if (town != null)
                {
                    town.Population += population;
                    town.Gold += gold;
                    continue;
                }
                Town newTown = new Town(cityName, population, gold);
                listOfTowns.Add(newTown);
            }

            string secondCommands = string.Empty;
            while ((secondCommands = Console.ReadLine()) != "End")
            {
                string[] data = secondCommands.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string action = data[0];
                if (action == "Plunder")
                {
                    if (!listOfTowns.Any(x => x.Name == data[1]))
                    {
                        continue;
                    }
                    else
                    {
                        Town town = listOfTowns.FirstOrDefault(x => x.Name == data[1]);
                        int population = int.Parse(data[2]);
                        int gold = int.Parse(data[3]);
                        int plunderedGold = 0;
                        int killedPpl = 0;
                        if (town.Population <= population)
                        {
                           killedPpl = population;
                            if (town.Gold <= gold)
                            {
                                plunderedGold = gold;
                                Console.WriteLine($"{town.Name} plundered! {plunderedGold} gold stolen, {killedPpl} citizens killed.");
                                Console.WriteLine($"{town.Name} has been wiped off the map!");
                                listOfTowns.Remove(town);
                                continue;
                            }
                            Console.WriteLine($"{town.Name} plundered! {gold} gold stolen, {killedPpl} citizens killed.");
                            Console.WriteLine($"{town.Name} has been wiped off the map!" );
                            listOfTowns.Remove(town);
                            continue;
                        }
                        if (town.Gold <= gold)
                        {
                            plunderedGold = gold;
                            Console.WriteLine($"{town.Name} plundered! {plunderedGold} gold stolen, {population} citizens killed.");
                            listOfTowns.Remove(town);
                            Console.WriteLine($"{town.Name} has been wiped off the map!");
                            continue;
                        }
                        Console.WriteLine($"{town.Name} plundered! {gold} gold stolen, {population} citizens killed.");
                        town.Population -= population;
                        town.Gold -= gold;

                        
                    }
                }
                else if (action == "Prosper")
                {
                    string cityName = data[1];
                    int gold = int.Parse(data[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }
                    var town = listOfTowns.FirstOrDefault(x=> x.Name == cityName);
                    if (town != null)
                    {
                        town.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town.Name} now has {town.Gold} gold.");
                    }
                }
            }
            if (listOfTowns.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }
            Console.WriteLine($"Ahoy, Captain! There are {listOfTowns.Count} wealthy settlements to go to:");
            foreach (var settlement in listOfTowns)
            {
                Console.WriteLine($"{settlement.Name} -> Population: {settlement.Population} citizens, Gold: {settlement.Gold} kg");
            }
        }
    }
}
