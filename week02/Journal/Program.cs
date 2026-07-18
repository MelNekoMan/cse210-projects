/*ENHANCEMENTS:
    1. Implemented Multi-Format Support allowing the user to save/load in both standard .txt and .csv (Excel) formats.
    2. Added robust error handling using int.TryParse() to prevent terminal crashes from invalid user inputs.
    3. Created dynamic file generation that prompts the user to automatically build a new file if the specified path does not exist.
    4. Integrated dynamic console color-coding (Green/Red/Yellow) to provide instant visual feedback on program operations.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int userChoice = -1;

        Console.WriteLine("=====================================");
        Console.WriteLine("  Welcome to the Journal Program!   ");
        Console.WriteLine("=====================================");

        while (userChoice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string input = Console.ReadLine();
            
            if (!int.TryParse(input, out userChoice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Please enter a valid number between 1 and 5.");
                Console.ResetColor();
                continue;
            }

            if (userChoice < 1 || userChoice > 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Error: Invalid option. Please choose a number from 1 to 5.");
                Console.ResetColor();
                continue;
            }

            if (userChoice == 1)
            {
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(randomPrompt);

                Console.Write("> ");
                string userResponse = Console.ReadLine();
                string currentDate = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = currentDate;
                newEntry._promptText = randomPrompt;
                newEntry._entryText = userResponse;

                theJournal.AddEntry(newEntry);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Entry successfully added to memory!");
                Console.ResetColor();
            }
            else if (userChoice == 2)
            {
                theJournal.DisplayAll();
            }
            else if (userChoice == 3)
            {
                int formatChoice = -1;

                while (formatChoice < 1 || formatChoice > 3)
                {
                    Console.WriteLine("\n--- Load Journal Options ---");
                    Console.WriteLine("1. Standard (.txt)");
                    Console.WriteLine("2. CSV / Excel (.csv)");
                    Console.WriteLine("3. <- Go Back to Main Menu");
                    Console.Write("Select a format: ");
                    
                    string formatInput = Console.ReadLine();
                    if (!int.TryParse(formatInput, out formatChoice))
                    {
                        Console.WriteLine("Error: Please enter a number between 1 and 3.");
                        continue;
                    }

                    if (formatChoice == 3)
                    {
                        Console.WriteLine("Returning to main menu...");
                        break; 
                    }

                    if (formatChoice == 1 || formatChoice == 2)
                    {
                        Console.Write("What is the filename? ");
                        string filename = Console.ReadLine();

                        if (formatChoice == 1)
                        {
                            if (!filename.EndsWith(".txt")) filename += ".txt";
                            theJournal.LoadFromFile(filename);
                        }
                        else if (formatChoice == 2)
                        {
                            if (!filename.EndsWith(".csv")) filename += ".csv";
                            theJournal.LoadFromCsv(filename);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    }
                }
                
                userChoice = -1;
            }
            else if (userChoice == 4)
            {
                int formatChoice = -1;

                while (formatChoice < 1 || formatChoice > 3)
                {
                    Console.WriteLine("\n--- Save Journal Options ---");
                    Console.WriteLine("1. Standard (.txt)");
                    Console.WriteLine("2. CSV / Excel (.csv)");
                    Console.WriteLine("3. <- Go Back to Main Menu");
                    Console.Write("Select a format: ");
                    
                    string formatInput = Console.ReadLine();
                    if (!int.TryParse(formatInput, out formatChoice))
                    {
                        Console.WriteLine("Error: Please enter a number between 1 and 3.");
                        continue;
                    }

                    if (formatChoice == 3)
                    {
                        Console.WriteLine("Returning to main menu...");
                        break; 
                    }

                    if (formatChoice == 1 || formatChoice == 2)
                    {
                        Console.Write("What is the filename? ");
                        string filename = Console.ReadLine();

                        if (formatChoice == 1)
                        {
                            if (!filename.EndsWith(".txt")) filename += ".txt";
                            theJournal.SaveToFile(filename);
                        }
                        else if (formatChoice == 2)
                        {
                            if (!filename.EndsWith(".csv")) filename += ".csv";
                            theJournal.SaveToCsv(filename);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                    }
                }
                
                userChoice = -1;
            }
        }

        Console.WriteLine("\nThank you for using your Journal. Goodbye!");
    }
}