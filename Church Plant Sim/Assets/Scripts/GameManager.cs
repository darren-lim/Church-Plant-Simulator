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

    [Header("Components")]
    public SliderChangeScript sliders;

    [Header("Number Values")]
    public float burnoutChangeValue;
    public float moodChangeValue;


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

        // Game events
        GameEvents.instance.onSundayEvent += itIsSunday;

        // Start the game loop
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
                // add beginning of sunday values

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
            }
            GameEvents.instance.NextDayEvent();
        }
    }

    public void itIsSunday()
    {
        isSunday = true;
    }

}
