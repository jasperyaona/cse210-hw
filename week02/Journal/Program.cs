// Added filename validation that automatically handles the .txt extension and verifies that the file exists before loading it, preventing errors from invalid filenames.
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int choice = 1;
        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                PromptGenerator prompt = new PromptGenerator();
                string message = prompt.GetRandomPrompt();
                Console.WriteLine(message);

                Entry entry = new Entry();
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                entry._date = dateText;
                entry._promptText = message;
                entry._entryText = Console.ReadLine();


                journal.AddEntry(entry);

            }

            if (choice == 2)
            {
                journal.DisplayAll();
            }

            if (choice == 3)
            {

                bool valid = false;
                while (!valid)
                {
                    Console.WriteLine("What is the filename(.txt)");
                    string filename = Console.ReadLine().Trim();
                    if (!filename.EndsWith(".txt"))
                    {
                        filename += ".txt";
                    }
                    if (File.Exists(Path.Combine("Entries", filename)))
                    {
                        journal.LoadFromFile(filename);
                        Console.WriteLine("File Loaded!");
                        Console.WriteLine();
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exists!");
                        Console.WriteLine();
                    }
                }

            }

            if (choice == 4)
            {
                Console.WriteLine("What is the filename(.txt)");
                string filename = Console.ReadLine().Trim();
                if (!filename.EndsWith(".txt"))
                {
                    filename += ".txt";
                }
                journal.SaveToFile(filename);
                Console.WriteLine("File Saved");
                Console.WriteLine();
            }

            if (choice == 5)
            {
                Console.WriteLine("Until Next Time");
                Console.WriteLine();
            }
        }





    }
}