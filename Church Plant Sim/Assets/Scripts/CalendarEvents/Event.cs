using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public Date eventDate;
    public float moodBoostVal;

    public Event(int day, int month, int year, int moodBoost)
    {
        eventDate = new Date(month, day, year);
        moodBoostVal = moodBoost;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string ReturnEventDate()
    {
        return eventDate.ToString();
    }
}
