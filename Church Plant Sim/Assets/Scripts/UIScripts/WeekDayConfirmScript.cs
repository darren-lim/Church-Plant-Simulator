using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeekDayConfirmScript : MonoBehaviour
{
    public GameObject weekDayUI;
    public GameObject danceUI;

    public int unallocPoints = 5;
    public TextMeshProUGUI pointsText;

    // public AddSubButtonsWD[] pointsList;

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
        if(!HasPoints())
        {
            GameEvents.instance.WeekdayConfirmEvent();
            disableWeekDay();
        }
    }

    public bool HasPoints()
    {
        if (unallocPoints > 0)
            return true;
        return false;
    }

    public void SubTotalPoints()
    {
        if(unallocPoints>0)
        {
            unallocPoints--;
            pointsText.text = unallocPoints.ToString();
        }
    }

    public void AddTotalPoints()
    {
        if(unallocPoints<5)
        {
            unallocPoints++;
            pointsText.text = unallocPoints.ToString();
        }
    }

    // subscribe to weekday event
    public void enableWeekday()
    {
        weekDayUI.SetActive(true);
        unallocPoints = 5;
        pointsText.text = "5";
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
