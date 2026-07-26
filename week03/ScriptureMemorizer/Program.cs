/* ENHANCEMENTS:
    1. A small Scripture Library was created.
    2. Case Insensitive: It doesn't matter whether the user enters the word "quit" in uppercase or lowercase.
    3. Hide only visible words: The program makes sure to select words that haven't been hidden yet so as not to waste attempts
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding."),
            new Scripture(new Reference("Alma", 37, 35), "O, remember, my son, and learn wisdom in thy youth; yea, learn in thy youth to keep the commandments of God."),
            new Scripture(new Reference("Mosiah", 2, 17), "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."),
            new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."),
        };

        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        string userInput = "";

        while (userInput != "quit" && userInput != "q" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            
            userInput = Console.ReadLine().ToLower().Trim();
            
            if (userInput != "quit" && userInput != "q")
            {
                scripture.HideRandomWords(3);                
            }
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}