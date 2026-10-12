using System;
using System.Collections.Generic;

List<Activity> activities = new List<Activity>
{
    new Running(new DateTime(2026, 10, 8), 30, 3.0),
    new Cycling(new DateTime(2026, 10, 9), 30, 12.0),
    new Swimming(new DateTime(2026, 10, 10), 30, 40)
};

foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}
