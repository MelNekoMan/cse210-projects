using System;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying = "yes";
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int userCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                userCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }

            }
            if (userCount <= 1)
            {
                Console.WriteLine("Impressive! you guessed it right the first time!");
            }
            else
            {
                Console.WriteLine($"You have tried {userCount} times");            
            }

            Console.Write("Would you like to play again (yes/no)? ");
            keepPlaying = Console.ReadLine().ToLower();
            
        } while (keepPlaying == "yes");
    }
}