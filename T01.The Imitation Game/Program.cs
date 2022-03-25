using System;

namespace T01.The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string code = string.Empty;
            while ((code= Console.ReadLine()) != "Decode")
            {
                string[] commandArgs = code.Split('|');
                string command = commandArgs[0];
                if (command == "Move")
                {
                    int letters = int.Parse(commandArgs[1]);
                    string substring = encryptedMessage.Substring(0, letters);
                    encryptedMessage = encryptedMessage.Remove(0, letters);
                    encryptedMessage = encryptedMessage + substring;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(commandArgs[1]);
                    string substring = commandArgs[2];
                    encryptedMessage = encryptedMessage.Insert(index, substring);
                }
                else if (command == "ChangeAll")
                {
                    string substring = commandArgs[1];
                    string replacement = commandArgs[2];
                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }
            Console.WriteLine($"The decrypted message is: " + encryptedMessage);
        }
    }
}
