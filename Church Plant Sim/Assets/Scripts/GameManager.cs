using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        GameEvents.instance.onSundayEvent += itIsSunday;
        StartCoroutine(NextDayCountdown());
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private IEnumerator NextDayCountdown()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(weekdayDuration);
            if (isSunday)
            {
                Debug.Log("It's Sunday");
                yield return new WaitForSeconds(sundayDuration);
                isSunday = false;
            }
            else
            {
                // weekday
            }
            GameEvents.instance.NextDayEvent();
        }
    }

    public void itIsSunday()
    {
        isSunday = true;
    }

}
