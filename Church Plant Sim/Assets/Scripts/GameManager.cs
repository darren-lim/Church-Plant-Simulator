using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 *  This script contains, controls and manipulates the main game loop.
 */

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
    // 1.66 is 10/6. 10 seconds for the length of sunday.
    // 6 is for 6 hours. the day goes from 2 to 8.
    public float divideNum = 1.66f;
    private float counterAdd = 1.66f;
    public float clockStart = 2f;
    private float clockTime = 2f;

    [Header("NPC List")]
    public NPCSpawner spawner;
    public int addVisitorAmount = 1;
    public int visitorCountLastWeek = 0;
    public int maxVisitorAmount = 3;
    public TextMeshProUGUI visitorListText;
    public TextMeshProUGUI memberListText;

    [Header("Budget Attributes")]
    public BudgetScript budgetScript;
    public float tithePerMember = 30f;


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
        budgetScript = GetComponent<BudgetScript>();

        // Pool NPCs
        spawner = GetComponent<NPCSpawner>();

        // Game events
        GameEvents.instance.onSundayEvent += itIsSunday;

        // Start the game loop
        StartCoroutine(PlayGameLoop());
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

    private IEnumerator PlayGameLoop()
    {
        while (Application.isPlaying)
        {
            if (isSunday)
            {
                // add beginning of sunday values
                clockText.text = "2:00";

                // idea? code for future: early game we start with small amount of visitors,
                // but late game a lot of visitors.

                // calculate visitor NPC values for today
                // enable members
                spawner.ActivateMembers();

                // this if statement checks if we have more than the visitor cap. if we do, dont add visitors.
                if (addVisitorAmount + visitorCountLastWeek <= maxVisitorAmount)
                    addVisitorAmount += visitorCountLastWeek;
                for(int i = 0; i < addVisitorAmount; i++)
                {
                    GameObject visitor = spawner.GetVisitorNPC();
                    if (visitor == null)
                    {
                        visitor = spawner.PoolMoreNPCs();
                    }
                }
                List<GameObject> newMembers = spawner.CalculateVisitorSunday();
                foreach(GameObject newMember in newMembers)
                {
                    Debug.Log(newMember.name + " has become a Member!");
                    newMember.GetComponent<NPC>().BecomeMember();
                }

                // change member and visitors lists
                // input of 1 is returns visitor list, input of 2 returns member list
                visitorListText.text = spawner.NPCListToString(1);
                memberListText.text = spawner.NPCListToString(2);

                StartCoroutine(Tithe());
                
                Debug.Log("It's Sunday");
                yield return new WaitForSeconds(sundayDuration);
                isSunday = false;

                // add end of the sunday values
                sliders.SetBurnoutSlider(sliders.GetBurnoutValue() + burnoutChangeValue);
                sliders.SetMoodSlider(sliders.GetMoodValue() - moodChangeValue);

                visitorCountLastWeek = addVisitorAmount;
                spawner.DeactivateAll();
                yield return new WaitForSeconds(1f);
            }
            else
            {
                // weekday
                counter = 0f;
                clockText.text = "Weekday...";
                clockTime = clockStart;
                divideNum = counterAdd;
                yield return new WaitForSeconds(weekdayDuration);
            }
            GameEvents.instance.NextDayEvent();
        }
    }

    private IEnumerator Tithe()
    {
        yield return new WaitForSeconds(2f);
        float titheAmount = spawner.memberCount * tithePerMember;
        budgetScript.AddTithe(titheAmount);
        yield return null;
    }

    public void itIsSunday()
    {
        isSunday = true;
    }
}
