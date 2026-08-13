using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running run = new Running("13 Aug 2026", 30, 4.8);
        StationaryBicycle bike = new StationaryBicycle("13 Aug 2026", 45, 20.0);
        Swimming swim = new Swimming("13 Aug 2026", 40, 40);

        activities.Add(run);
        activities.Add(bike);
        activities.Add(swim);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}