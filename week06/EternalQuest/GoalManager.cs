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
        bool running = true;

        while (running)
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 7.\n");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = (_score / 500) + 1;
        int pointsToNextLevel = 500 - (_score % 500);

        Console.WriteLine("You have " + _score + " points.");
        Console.WriteLine("Quest Level: " + level);
        Console.WriteLine("Points to next level: " + pointsToNextLevel + "\n");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.\n");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _goals[i].GetShortName());
        }
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.\n");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _goals[i].GetDetailsString());
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description? ");
        string description = Console.ReadLine();
        int points = ReadPositiveOrZeroInt("How many points is this goal worth? ");

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("The name and description cannot be empty.\n");
            return;
        }

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                int target = ReadPositiveInt("How many times must this goal be completed? ");
                int bonus = ReadPositiveOrZeroInt("How many bonus points are earned when completed? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("That goal type is not valid.\n");
                return;
        }

        Console.WriteLine("Goal created successfully.\n");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record yet.\n");
            return;
        }

        ListGoalNames();
        int choice = ReadPositiveInt("Which goal did you accomplish? ");
        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("That goal number is not valid.\n");
            return;
        }

        Goal goal = _goals[choice - 1];
        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine("That simple goal has already been completed.\n");
            return;
        }

        bool wasComplete = goal.IsComplete();

        if (goal is ChecklistGoal && wasComplete)
        {
            Console.WriteLine("That checklist goal is already complete.\n");
            return;
        }

        goal.RecordEvent();
        _score += goal.GetPoints();

        ChecklistGoal checklist = goal as ChecklistGoal;
        if (checklist != null && !wasComplete && checklist.IsComplete())
        {
            _score += checklist.GetBonus();
            Console.WriteLine("You earned " + checklist.GetBonus() + " bonus points!");
        }

        Console.WriteLine("Good job! You earned " + goal.GetPoints() + " points.\n");
    }

    public void SaveGoals()
    {
        Directory.CreateDirectory("data");
        string fileName = ReadFileName("Enter a file name to save (example: goals.txt): ");
        if (fileName == null)
        {
            return;
        }

        string filePath = Path.Combine("data", fileName);
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully to " + filePath + ".\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not save the file: " + ex.Message + "\n");
        }
    }

    public void LoadGoals()
    {
        Directory.CreateDirectory("data");
        string fileName = ReadFileName("Enter a file name to load (example: goals.txt): ");
        if (fileName == null)
        {
            return;
        }

        string filePath = Path.Combine("data", fileName);
        if (!File.Exists(filePath))
        {
            Console.WriteLine("That file was not found in the data folder.\n");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.\n");
                return;
            }

            int loadedScore;
            if (!int.TryParse(lines[0], out loadedScore))
            {
                Console.WriteLine("The file format is invalid.\n");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                int points;
                if (parts.Length < 4 || !int.TryParse(parts[3], out points))
                {
                    continue;
                }

                if (parts[0] == "Simple" && parts.Length == 5)
                {
                    bool complete;
                    if (bool.TryParse(parts[4], out complete))
                    {
                        loadedGoals.Add(new SimpleGoal(parts[1], parts[2], points, complete));
                    }
                }
                else if (parts[0] == "Eternal" && parts.Length == 4)
                {
                    loadedGoals.Add(new EternalGoal(parts[1], parts[2], points));
                }
                else if (parts[0] == "Checklist" && parts.Length == 7)
                {
                    int target;
                    int bonus;
                    int completed;
                    if (int.TryParse(parts[4], out target)
                        && int.TryParse(parts[5], out bonus)
                        && int.TryParse(parts[6], out completed))
                    {
                        loadedGoals.Add(new ChecklistGoal(parts[1], parts[2], points, target, bonus, completed));
                    }
                }
            }

            _goals.Clear();
            _goals.AddRange(loadedGoals);
            _score = loadedScore;
            Console.WriteLine("Loaded " + _goals.Count + " goals and " + _score + " points.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not load the file: " + ex.Message + "\n");
        }
    }

    private string ReadFileName(string prompt)
    {
        Console.Write(prompt);
        string fileName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("File name cannot be empty.\n");
            return null;
        }

        // Only accept a the file name, not a path supplied by the user.
        if (Path.GetFileName(fileName) != fileName)
        {
            Console.WriteLine("Please enter only a file name, not a folder path.\n");
            return null;
        }

        return fileName;
    }

    private int ReadPositiveOrZeroInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
            {
                return value;
            }
            Console.WriteLine("Please enter a number that is zero or greater.");
        }
    }

    private int ReadPositiveInt(string prompt)
    {
        int value;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("Please enter a number greater than zero.");
        }
    }
}
