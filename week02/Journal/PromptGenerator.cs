
using System;

public class PromptGenerator()
{
    public List<string> _prompts;

    public string GetRandomPrompt()
    {
        _prompts = new List<string>();
        Random random = new Random();
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("if I had one thing I could do over today, what would it be?");
        return _prompts[random.Next(_prompts.Count)];
    }
}