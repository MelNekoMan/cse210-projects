using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts[0];
                    loadedEntry._promptText = parts[1];
                    loadedEntry._entryText = parts[2];

                    AddEntry(loadedEntry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("Error: File not found.");
        }
    }

    public void SaveToCsv(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date;Prompt;Entry");

            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date};{entry._promptText};{entry._entryText}");
            }
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Journal exported to CSV successfully!");
        Console.ResetColor();
    }

    public void LoadFromCsv(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(';');

                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = parts[0];
                    loadedEntry._promptText = parts[1];
                    loadedEntry._entryText = parts[2];

                    AddEntry(loadedEntry);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CSV loaded successfully!");
            Console.ResetColor();
        }
        else
        {
            Console.Write($"The file '{file}' does not exist. Would you like to create it as a new empty file? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response == "yes" || response == "y")
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine("Date;Prompt;Entry");
                }
                _entries.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Empty CSV file successfully created!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Load canceled.");
                Console.ResetColor();
            }
        }
    }
}