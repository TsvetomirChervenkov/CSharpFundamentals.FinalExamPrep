using System;
using System.Collections.Generic;
using System.Linq;

namespace T43.Heroes_of_Code_and_Logic_VII
{
    class Heroes
    {
        public Heroes(string name, int health, int mana)
        {
            this.Name = name;
            this.Health = health;
            this.Mana = mana;
        }
        public string Name { get; set; }
        public int  Health { get; set; }
        public int Mana { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Heroes> company = new List<Heroes>();

            GetOurCompanyOfHeroes(company);

            string cmd;
            while ((cmd= Console.ReadLine()) != "End")
            {
                string[] cmdInfo = cmd.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdInfo[0];
                if (command == "CastSpell")
                {
                    string heroName = cmdInfo[1];
                    int manaNeeded = int.Parse(cmdInfo[2]);
                    string spellName = cmdInfo[3];
                    var searchedHero = company.FirstOrDefault(x => x.Name == heroName);
                    if (searchedHero.Mana >= manaNeeded)
                    {
                        Console.WriteLine($"{searchedHero.Name} has successfully cast {spellName} and now has {searchedHero.Mana-manaNeeded} MP!");
                        searchedHero.Mana-= manaNeeded;
                        continue;
                    }
                    Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                }
                else if (command == "TakeDamage")
                {
                    string heroName = cmdInfo[1];
                    int damage = int.Parse(cmdInfo[2]);
                    string attacker = cmdInfo[3];
                    var searchedHero = company.FirstOrDefault(x => x.Name == heroName);
                    if (searchedHero.Health - damage <= 0)
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        company.Remove(searchedHero);
                        continue;
                    }
                    Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {searchedHero.Health-damage} HP left!");
                    searchedHero.Health -= damage;
                }
                else if (command == "Recharge")
                {
                    string heroName = cmdInfo[1];
                    int manaRecharged = int.Parse(cmdInfo[2]);
                    var searchedHero = company.FirstOrDefault(x => x.Name == heroName);
                    if (searchedHero.Mana+manaRecharged > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {Math.Abs(searchedHero.Mana - 200)} MP!");
                        searchedHero.Mana = 200;
                        continue;
                    }
                    searchedHero.Mana += manaRecharged;
                    Console.WriteLine($"{heroName} recharged for {manaRecharged} MP!");
                }
                else if (command == "Heal")
                {
                    string heroName = cmdInfo[1];
                    int healthRecharged = int.Parse(cmdInfo[2]);
                    var searchedHero = company.FirstOrDefault(x => x.Name == heroName);
                    if (searchedHero.Health + healthRecharged > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {Math.Abs(searchedHero.Health - 100)} HP!");
                        searchedHero.Health = 100;
                        continue;
                    }
                    Console.WriteLine($"{heroName} healed for {healthRecharged} HP!");
                    searchedHero.Health += healthRecharged;
                }

            }
            foreach (var hero in company)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.Health}");
                Console.WriteLine($"  MP: {hero.Mana}");
            }

        }
        static void GetOurCompanyOfHeroes(List<Heroes> company)
        {
            int characters = int.Parse(Console.ReadLine());
            for (int i = 0; i < characters; i++)
            {
                string[] heroInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string heroName = heroInfo[0];
                int heroHealth = int.Parse(heroInfo[1]);
                int heroMana = int.Parse(heroInfo[2]);
                Heroes hero = new Heroes(heroName, heroHealth, heroMana);
                company.Add(hero);
            }
        }
        
    }
}
