using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.The_Pianist
{
    class Piece
    {
        public Piece(string pieces, string composer, string key)
        {
            this.Pieces = pieces;
            this.Composer = composer;
            this.Key = key; 
        }
        public string Pieces { get; set; }
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> list = new Dictionary<string, Piece>();
            int numOfPiece = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfPiece ;  i++)
            {
                string[] info = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string composer = info[1];
                string piece = info[0];
                string key = info[2];
                Piece newPiece = new Piece(piece, composer, key);
                list.Add(piece, newPiece);
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Stop")
            {
                string[] commandsArgs = commands.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArgs[0];
                if (action == "Add")
                {
                    string piece = commandsArgs[1];
                    string composer = commandsArgs[2];
                    string key = commandsArgs[3];
                    if (list.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                        continue;
                    }
                    Piece newPiece = new Piece(piece, composer, key);
                    list.Add(piece,newPiece);
                    Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                }
                else if (action == "Remove")
                {
                    string piece = commandsArgs[1];
                    if (!list.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        continue;
                    }
                    list.Remove(piece);
                    Console.WriteLine($"Successfully removed {piece}!");
                }
                else if (action == "ChangeKey")
                {
                    string piece = commandsArgs[1];
                    string newKey = commandsArgs[2];
                    if (!list.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        continue;
                    }
                    list[piece].Key = newKey;
                    Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                }
            }
            foreach (var piece in list)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}
