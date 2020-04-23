using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
*
*   This class is only for the Unity Events system and for
*   classes in the game to subscribe to events
*
**/
public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
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
    public event Action onNextDayEvent;
    public event Action onSundayEvent;
    public event Action onWeekdayStartEvent;
    public void NextDayEvent()
    {
        if (onNextDayEvent != null)
        {
            onNextDayEvent();
        }
    }

    public void SundayEvent()
    {
        if (onSundayEvent != null)
        {
            onSundayEvent();
        }
    }

    public void WeekdayStartEvent()
    {
        if (onWeekdayStartEvent != null)
        {
            onWeekdayStartEvent();
        }
    }
}
