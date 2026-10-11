using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals can be recorded endlessly, so no ccompletion state is needed. UwU
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return "[ ] " + GetShortName() + " (" + GetDescription() + ")";
    }

    public override string GetStringRepresentation()
    {
        return "Eternal|" + GetShortName() + "|" + GetDescription() + "|" + GetPoints();
    }
}
