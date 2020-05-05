using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Date
{
    // 28 Days in a month
    // Keeping it exactly 4 weeks in a month
    public int Day { get; set; }
    // 12 Months in a year
    public int Month { get; set; }
    public int Year { get; set; }

    public Date()
    {
        Day = 1;
        Month = 1;
        Year = 2000;
    }

    public Date(int m, int d, int y)
    {
        // day
        Day = d;

        // month
        Month = m;

        Year = Mathf.Abs(y);
    }

    // Returns Date in an integer array
    public int[] ReturnDate()
    {
        return new int[3] { Day, Month, Year };
    }

    // Date to string output
    public override string ToString()
    {
        return Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
    }
}
