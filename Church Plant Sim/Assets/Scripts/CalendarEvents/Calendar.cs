using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar instance;
    private Date currDate;
    [Header("Calendar attributes")]
    public int DaysInMonth = 28;
    public Event[] Events;

    [Header("Calendar statistics")]
    public int weekNum = 1;
    public int dayNum = 1;
    public int monthNum = 1;
    public int yearNum = 1;
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
        currDate = new Date(dayNum, monthNum, yearNum);
        Debug.Log(currDate.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Make this an event
    public void nextDay()
    {
        currDate.Day += 1;
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
            currDate.Day = 1;
            currDate.Month += 1;
            monthNum += 1;
            if (currDate.Month > 12)
            {
                currDate.Month = 1;
                currDate.Year += 1;
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
