using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.The_Pianist
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] array = new string[3] { "menopause", "catastropher", "delphi" };
            string wordToGuess5 = array[random.Next(3)];
            string wordToGuess = "hello";
            Console.WriteLine("Let's play a game: ");
            Console.WriteLine($"The word you are looking for has: {wordToGuess.Length} letters!");
            Console.WriteLine($"Rules: You have 3 errors.");
            Console.WriteLine($"Rules: 4th error you lose.");
            Console.WriteLine($"Start!");
            int errors = 0;
            
            string guess = Console.ReadLine();
            while (errors != 4)
            {
             
                char[] word = wordToGuess.ToArray();
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == guess[0])
                    {
                        Console.Write($"{guess}");
                        
                    }
                    Console.Write($"*");
                   
                }
                Console.WriteLine();
                guess = Console.ReadLine();
                
            }
        }
    }
}
