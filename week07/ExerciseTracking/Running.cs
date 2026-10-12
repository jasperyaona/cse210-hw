using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }
}
