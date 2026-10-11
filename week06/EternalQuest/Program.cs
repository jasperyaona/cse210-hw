// Exceedig requirements: the program includes a quest-level system.
// Every 500 points increases the user's level and displays progress toward the next level.
// Also splitted goal names and details
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
