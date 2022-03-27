using System;
using System.Linq;

namespace T01.Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secretMsg = Console.ReadLine();
            string data = string.Empty;

            while ((data = Console.ReadLine()) != "Reveal")
            {
                string[] dataArgs = data.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = dataArgs[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(dataArgs[1]);
                    secretMsg = secretMsg.Insert(index, " ");
                    Console.WriteLine(secretMsg);
                }
                else if (command == "Reverse")
                {
                    string wantedSub = dataArgs[1];
                    if (secretMsg.Contains(wantedSub))
                    {
                        char[] wantedSub2 = wantedSub.ToCharArray();
                        Array.Reverse(wantedSub2);
                        string newSubstring = string.Join("", wantedSub2).ToString();
                        var index = secretMsg.IndexOf(wantedSub);
                        secretMsg = secretMsg.Remove(index, wantedSub.Length);
                        secretMsg = secretMsg + newSubstring;
                        Console.WriteLine(secretMsg);
                    }
                    else if (!secretMsg.Contains(wantedSub))
                    {
                        Console.WriteLine($"error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string wantedSub = dataArgs[1];
                    string newSub = dataArgs[2];
                    if (secretMsg.Contains(wantedSub))
                    {
                        secretMsg = secretMsg.Replace(wantedSub, newSub);
                        Console.WriteLine(secretMsg);
                    }
                }
            }
            Console.WriteLine($"You have a new text message: " + secretMsg);
        }
    }
}
