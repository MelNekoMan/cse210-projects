using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
  private List<Goal> _goals;
  private int _score;

  public GoalManager()
  {
    _goals = new List<Goal>();
    _score = 0;
  }

  public void Start()
  {
    string choice = "";
    while (choice != "6")
    {
      Console.Clear();
      DisplayPlayerInfo();
      Console.WriteLine("Menu Options:");
      Console.WriteLine("  1. Create New Goal");
      Console.WriteLine("  2. List Goals");
      Console.WriteLine("  3. Save Goals (CSV)");
      Console.WriteLine("  4. Load Goals (CSV)");
      Console.WriteLine("  5. Record Event");
      Console.WriteLine("  6. Quit");
      Console.Write("Select a choice from the menu: ");

      choice = Console.ReadLine();

      Console.WriteLine();
      switch (choice)
      {
        case "1":
        CreateGoal();
        break;
        case "2":
        ListGoalDetails();
        break;
        case "3":
        SaveGoals();
        break;
        case "4":
        LoadGoals();
        break;
        case "5":
        RecordEvent();
        break;
        case "6":
        Console.WriteLine("Thank you for using Eternal Quest! Goodbye!");
        break;
        default:
        Console.WriteLine("Invalid option. Press Enter to try again.");
        break;
      }

      if (choice != "6")
      {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
      }
    }
  }

  public void DisplayPlayerInfo()
  {
    int level = (_score / 1000) + 1;
    int pointsInCurrentLevel = _score % 1000;
    string rankTitle = GetRankTitle(level);

    Console.WriteLine("==================================================");
    Console.WriteLine($" You have {_score} points. | Level: {level} ({rankTitle})");

    int progressBars = pointsInCurrentLevel / 100;
    string progressBar = new string('=', progressBars) + new string(' ', 10 - progressBars);
    Console.WriteLine($" Progress to Level {level + 1}: [{progressBar}] {pointsInCurrentLevel}/1000 pts");
    Console.WriteLine("==================================================\n");
  }

  private string GetRankTitle(int level)
  {
    if (level == 1) return "Novice Adventurer";
    if (level == 2) return "Apprentice Guardian";
    if (level <= 4) return "Seasoned Explorer";
    return "Legendary Quest Master";
  }

  public void ListGoalDetails()
  {
    Console.WriteLine("The goals are:");
    if (_goals.Count == 0)
    {
      Console.WriteLine(" (No goals found. Create or load some goals first!)");
      return;
    }

    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($" {i + 1}. {_goals[i].GetDetailsString()}");
    }
  }

  public void CreateGoal()
  {
    Console.WriteLine("The types of Goals are:");
    Console.WriteLine("  1. Simple Goal");
    Console.WriteLine("  2. Eternal Goal");
    Console.WriteLine("  3. Checklist Goal");
    Console.Write("Which type of goal would you like to create?: ");
    string typeChoice = Console.ReadLine()?.Trim().ToLower();

    if (typeChoice == "q")
    {
      Console.WriteLine("Goal creation canceled.");
      return;
    }

    if (typeChoice !="1" && typeChoice !="2" && typeChoice != "3")
    {
      Console.WriteLine("Invalid goal type selected. Please try again.");
      return;
    }

    Console.Write("What is the name of your goal?: ");
    string name = Console.ReadLine();

    Console.Write("What is a short description of it?: ");
    string description = Console.ReadLine();

    int? points = PromptForInt("How many points do you want to assign to this goal?: ");
    if (points == null)
    {
      Console.WriteLine("Goal creation canceled.");
      return;
    }

    if (typeChoice == "1")
    {
      _goals.Add(new SimpleGoal(name, description, points.Value));
      Console.WriteLine("Simple goal created successfully!");
    }
    else if (typeChoice == "2")
    {
      _goals.Add(new EternalGoal(name, description, points.Value));
      Console.WriteLine("Eternal goal created successfully!");
    }
    else if (typeChoice == "3")
    {
      int? target = PromptForInt("How many times does this goal need to be accomplished for a bonus?: ");
      if (target == null)
      {
        Console.WriteLine("Goal creation cancelled.");
        return;
      }

      int? bonus = PromptForInt("What is the bonus for accomplishing it that many times?: ");
      if (bonus == null)
      {
        Console.WriteLine("Goal creation canceled.");
        return;
      }

      _goals.Add(new ChecklistGoal(name, description, points.Value, target.Value, bonus.Value));
      Console.WriteLine("Checklist goal created successfully!");
    }
  }

  public void RecordEvent()
  {
    if (_goals.Count == 0)
    {
      Console.WriteLine("You have no goals to record!");
      return;
    }

    Console.WriteLine("The goals are:");
    for (int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($" {i + 1}. {_goals[i].GetShortName()}");
    }

    int? selection = PromptForInt("Which goal did you accomplish?: ");
    if (selection == null)
    {
      Console.WriteLine("Event recording canceled.");
      return;
    }

    int goalIndex = selection.Value - 1;

    if (goalIndex >= 0 && goalIndex < _goals.Count)
    {
      Goal selectedGoal = _goals[goalIndex];

      if (selectedGoal.IsComplete())
      {
        Console.WriteLine("This goal is already completed!");
        return;
      }

      int pointsEarned = selectedGoal.RecordEvent();
      _score += pointsEarned;

      Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
      Console.WriteLine($"You now have {_score} points");
    }
    else
    {
      Console.WriteLine("Invalid goal selection.");
    }
  }

  public void SaveGoals()
  {
    Console.Write("What is the filename of your goals that you want to save? (e.g. goals.csv | Press Enter to create 'goals.csv') ");
    string input = Console.ReadLine();
    string filename = EnsureCsvExtension(input);

    using (StreamWriter outputFile = new StreamWriter(filename))
    {
      outputFile.WriteLine($"Score,{_score}");

      foreach (Goal goal in _goals)
      {
        outputFile.WriteLine(goal.GetStringRepresentation());
      }
    }

    Console.WriteLine($"Goals successfully saved to {filename}!");
  }

  public void LoadGoals()
  {
    Console.Write("What is the filename of your goals that you want to load (e.g. goals.csv)? ");
    string input = Console.ReadLine();
    string filename = EnsureCsvExtension(input);

    if (!File.Exists(filename))
    {
      Console.WriteLine("\nFile '{filename} not found!");
      Console.Write("Do you want to create a new CSV file? (y/n): ");
      string response = Console.ReadLine().Trim().ToLower();

      if (response == "y" || response == "yes")
      {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
          outputFile.WriteLine("Score,0");
        }

        _score = 0;
        _goals.Clear();
        Console.WriteLine($"\nNew goal file '{filename}' created and loaded successfully!");
      }
      else
      {
        Console.WriteLine("Load cancelled. Returning to Main Menu.");
      }
      return;
    }
    
    _goals.Clear();
    string[] lines = File.ReadAllLines(filename);

    if (lines.Length == 0) return;

    string[] scoreParts = lines[0].Split(',');
    if (scoreParts[0] == "Score")
    {
      _score = int.Parse(scoreParts[1]);
    }

    for (int i = 1; i < lines.Length; i++)
    {
      string line = lines[i];
      if (string.IsNullOrWhiteSpace(line)) continue;

      string[] mainParts = line.Split(':');
      string goalType = mainParts[0];
      string[] data = mainParts[1].Split(',');

      if (goalType == "SimpleGoal")
      {
        string name = data[0];
        string description = data[1];
        int points = int.Parse(data[2]);
        bool isComplete = bool.Parse(data[3]);
        _goals.Add(new SimpleGoal(name, description, points, isComplete));
      }
      else if (goalType == "EternalGoal")
      {
        string name = data[0];
        string description = data[1];
        int points = int.Parse(data[2]);
        _goals.Add(new EternalGoal(name, description, points));
      }
      else if (goalType == "ChecklistGoal")
      {
        string name = data[0];
        string description = data[1];
        int points = int.Parse(data[2]);
        int bonus = int.Parse(data[3]);
        int target = int.Parse(data[4]);
        int amountCompleted = int.Parse(data[5]);
        _goals.Add(new ChecklistGoal(name, description, points, amountCompleted, target, bonus));
      }
    }

    Console.WriteLine($"\nGoals successfully loaded from {filename}!");
  }

  private string EnsureCsvExtension(string filename)
  {
    if (string.IsNullOrWhiteSpace(filename))
    {
      return "goals.csv";
    }

    filename = filename.Trim();

    if (!filename.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
    {
      filename += ".csv";
    }

    return filename;
  }

  private int? PromptForInt(string promptMessage)
  {
    while (true)
    {
      Console.Write(promptMessage);
      string input = Console.ReadLine()?.Trim();

      if (input?.ToLower() == "q")
      {
        return null;
      }

      if (int.TryParse(input, out int result) && result >= 0)
      {
        return result;
      }

      Console.WriteLine("Invalid input. Please enter numbers only, or type 'q' to to return to the Main Menu.\n");
    }
  }
}