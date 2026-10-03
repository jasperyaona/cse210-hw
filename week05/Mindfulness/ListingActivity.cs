using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _responses;

    public ListingActivity()
    {
        Name = "Listing Activity";

        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _responses = new List<string>();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);

        Console.WriteLine($"--- {_prompts[promptIndex]} ---");

        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        Console.WriteLine();
        Console.WriteLine("Start listing your responses.");
        Console.WriteLine();

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                _responses.Add(response);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_responses.Count} items.");

        DisplayEndingMessage();
    }
}