
using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

      protected string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    protected string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    protected int Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }
    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");

        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animation = new List<string>()
        {
            "|", "/", "-", "\\"
        };

        DateTime startTime = DateTime.Now;
        int i = 0;

        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(animation[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;

            if (i >= animation.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}