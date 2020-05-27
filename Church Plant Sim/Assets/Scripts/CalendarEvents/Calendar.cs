using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar instance;
    private Date currDate;
    [Header("Calendar attributes")]
    public int DaysInMonth = 28;
    public int currentDay = 1;
    public int currentMonth = 2;
    public int currentYear = 2014;
    public Event[] Events;

    [Header("Calendar statistics")]
    public int weekNum = 1;
    public int dayNum = 1;
    public int monthNum = 2;
    public int yearNum = 2014;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onNextDayEvent += nextDay;
        currDate = new Date(currentMonth, currentDay, currentYear);
        Debug.Log("Start Date: " + currDate.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Make this an event
    public void nextDay()
    {
        currentDay += 1;
        currDate.Day = currentDay;
        dayNum += 1;
        if (currDate.Day % 7 == 1)
        {
            newWeek();
        }
        else if (currDate.Day % 7 == 2)
        {
            weekDayStart();
        }
        if (currDate.Day > DaysInMonth)
        {
            currentDay = 1;
            currDate.Day = currentDay;

            currentMonth += 1;
            currDate.Month = currentMonth;
            monthNum += 1;

            currentMonth = currDate.Month;
            if (currDate.Month > 12)
            {
                currentMonth = 1;
                currDate.Month = currentMonth;

                currentYear += 1;
                currDate.Year = currentYear;
                yearNum += 1;
            }
        }

        UIManagerScript.instance.UpdateDate(currDate.ToString());
    }

    public void newWeek()
    {
        weekNum += 1;
        // This event will only let the Game Manager know it is a new week sunday
        GameEvents.instance.SundayEvent();
    }

    public void weekDayStart()
    {
        // new week day, its a monday!
        GameEvents.instance.WeekdayStartEvent();
    }

    public string returnCurrDate()
    {
        return currDate.ToString();
    }
}
