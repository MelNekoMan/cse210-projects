using System;

/*
===============================================================================
EXCEEDING ENHANCEMENTS:
1. Activity Counter Log: Added a tracking mechanism that maintains a session log 
   of how many times each mindfulness activity (Breathing, Reflection, Listing) 
   was completed.
2. No-Repeat Prompts & Questions System: Implemented random selection logic in 
   ReflectingActivity that tracks previously shown prompts/questions to ensure 
   no item repeats until the entire list has been displayed at least once.
===============================================================================
*/

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                Console.Clear();
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                Console.WriteLine("\n--- Session Activity Log ---");
                Console.WriteLine($"Breathing Activities completed: {breathingCount}");
                Console.WriteLine($"Reflecting Activities completed: {reflectingCount}");
                Console.WriteLine($"Listing Activities completed: {listingCount}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("\nAnd always remember, God and Jesus loves you. Have a great day!");
            }
            else
            {
                Console.WriteLine("\nInvalid option. Press enter to try again.");
                Console.ReadLine();
            }
        }
    }
}