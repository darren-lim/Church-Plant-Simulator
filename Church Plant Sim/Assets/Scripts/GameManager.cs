﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // make gamestart an event, when the game is ready (after tutorial) then start the timer?
    // or start right away
    [Header("Game Boolean Values")]
    public bool gameStart = false;
    public bool isSunday = true;

    [Header("Time Values")]
    public float sundayDuration = 10f;
    public float weekdayDuration = 1f;

    [Header("Components")]
    public SliderChangeScript sliders;

    [Header("Number Values")]
    public float burnoutChangeValue;
    public float moodChangeValue;

    [Header("Clock Attrubutes")]
    public float counter = 0f;
    public TextMeshProUGUI clockText;
    // 1.83 is 11/6. 11 seconds for the 10 seconds of sunday + 1 second between each day.
    // 6 is for 6 hours. the day goes from 2 to 8.
    public float divideNum = 1.83f;
    private float counterAdd = 1.83f;
    public float clockStart = 2f;
    private float clockTime = 2f;


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

    // Start is called before the first frame update
    private void Start()
    {
        // Starting values
        sliders = GetComponent<SliderChangeScript>();
        burnoutChangeValue = 2f;
        moodChangeValue = 2f;
        counterAdd = divideNum;
        clockTime = clockStart;

        // Game events
        GameEvents.instance.onSundayEvent += itIsSunday;

        // Start the game loop
        StartCoroutine(NextDayCountdown());
    }

    // Update is called once per frame
    private void Update()
    {
        if (isSunday)
        {
            counter += Time.deltaTime;
            if(counter >= divideNum)
            {
                clockTime += 1;
                clockText.text = clockTime.ToString() + ":00";
                divideNum += counterAdd;
            }
        }
    }

    private IEnumerator NextDayCountdown()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(weekdayDuration);
            if (isSunday)
            {
                // add beginning of sunday values
                clockText.text = "2:00";
                Debug.Log("It's Sunday");
                yield return new WaitForSeconds(sundayDuration);
                isSunday = false;

                // add end of the sunday values
                sliders.SetBurnoutSlider(sliders.GetBurnoutValue() + burnoutChangeValue);
                sliders.SetMoodSlider(sliders.GetMoodValue() - moodChangeValue);
            }
            else
            {
                // weekday
                counter = 0f;
                clockText.text = "Weekday...";
                clockTime = clockStart;
                divideNum = counterAdd;
            }
            GameEvents.instance.NextDayEvent();
        }
    }

    public void itIsSunday()
    {
        isSunday = true;
    }

}
