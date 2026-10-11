using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string status = " ";
        if (_isComplete)
        {
            status = "X";
        }

        return "[" + status + "] " + GetShortName() + " (" + GetDescription() + ")";
    }

    public override string GetStringRepresentation()
    {
        return "Simple|" + GetShortName() + "|" + GetDescription() + "|" + GetPoints() + "|" + _isComplete;
    }
}
