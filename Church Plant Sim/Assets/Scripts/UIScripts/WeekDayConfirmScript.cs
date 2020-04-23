using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekDayConfirmScript : MonoBehaviour
{
    public GameObject weekDayUI;
    public GameObject danceUI;
    public TMP_Dropdown classDropdown;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onWeekdayStartEvent += enableWeekday;
        GameEvents.instance.onSundayEvent += disableDance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void confirmButton()
    {
        switch (classDropdown.value)
        {
            case 0:
                // add some effect to dropdown
                Debug.Log("Choose an option");
                break;
            // music
            case 1:
                // add some exp to this skill
                disableWeekDay();
                break;

            // fellowship
            case 2:
                disableWeekDay();
                break;

            // Teaching
            case 3:
                disableWeekDay();
                break;

            // Serving
            case 4:
                disableWeekDay();
                break;

            // Spirituality
            case 5:
                disableWeekDay();
                break;

        }
        Debug.Log(classDropdown.value);
    }

    // subscribe to weekday event
    public void enableWeekday()
    {
        weekDayUI.SetActive(true);
        Debug.Log("Weekday Start");
        Time.timeScale = 0;
    }

    void disableWeekDay()
    {
        Time.timeScale = 1;
        danceUI.SetActive(true);
        weekDayUI.SetActive(false);
    }

    // subscribe to sunday event
    void disableDance()
    {
        danceUI.SetActive(false);
    }
}
