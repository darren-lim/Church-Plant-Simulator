using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event
{
    public Date eventDate;
    public string eventName;
    public string eventDescription;
    //public float moodBoostVal;

    public Event(int day, int month, int year, string eName, string eDesc)
    {
        eventDate = new Date(month, day, year);
        eventName = eName;
        eventDescription = eDesc;

        //moodBoostVal = moodBoost;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public override string ToString()
    {
        return eventDate.ToString() + " " + eventName + " " + eventDescription;
    }
}
