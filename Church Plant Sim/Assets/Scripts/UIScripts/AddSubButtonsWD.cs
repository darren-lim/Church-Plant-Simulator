using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
 * 
 * Mainly Weekday Use (WD = WeekDay)
 * 
 */
public class AddSubButtonsWD : MonoBehaviour
{
    public WeekDayConfirmScript weekdayScript;
    public TextMeshProUGUI skillPointText;
    public int points = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(skillPointText == null)
        {
            Debug.Log("Please Assign skill points text");
        }
        if(weekdayScript == null)
        {
            Debug.Log("Please Assign week day confirm script");
        }
    }

    private void OnEnable()
    {
        skillPointText.text = "0";
        points = 0;
    }

    public void AddPoint()
    {
        if (weekdayScript.HasPoints())
        {
            weekdayScript.SubTotalPoints();
            points++;
            skillPointText.text = points.ToString();
        }
    }

    public void SubPoint()
    {
        if (points > 0)
        {
            weekdayScript.AddTotalPoints();
            points--;
            skillPointText.text = points.ToString();
        }
    }
}
