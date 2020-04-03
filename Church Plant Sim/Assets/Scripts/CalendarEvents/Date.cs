using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date : MonoBehaviour
{
    // 30 Days in a month
    public int Day;
    // 12 Months in a year
    public int Month;
    public int Year;

    public Date(int m, int d, int y)
    {
        // day
        if (d > 30)
            Day = d % 30;
        else if (d < 1)
            Day = 1;
        else
            Day = d;

        // month
        if (m > 12)
            Month = 12 % m;
        else if (m < 1)
            Month = 1;
        else
            Month = m;

        Year = Mathf.Abs(y);
    }

    public void AddOneDay()
    {
        Day += 1;
        if (Day > 30)
        {
            Day = 1;
            Month += 1;
            if (Month > 12)
            {
                Month = 1;
                Year += 1;
            }
        }
    }

    public override string ToString()
    {
        return Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
    }
}
