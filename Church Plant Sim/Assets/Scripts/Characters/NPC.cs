using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class NPC : Character
{
    [Header("NPC Attributes")]
    public string skill;
    public Date dateJoined;
    // if is member is false, then we are visitor
    public bool isMember = false;
    public string CharacterName;
    public string servingTeam;

    [Header("NPC UI Attributes")]
    public GameObject uiCanvas;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI isMemberText;
    public TextMeshProUGUI skillText;
    public TextMeshProUGUI servingTeamText;
    public TextMeshProUGUI moodText;
    public TextMeshProUGUI burnText;


    [Header("Member Attributes")]
    public string ServingTeam;

    [Header("Visitor Attributes")]
    // chance out of 100
    public float maxChance = 100f;
    public float chanceToBecomeMember = 50f;
    public float successfulSundays = 100f;

    [Header("Name List")]
    string[] nameComponent1 = new string[] { "Darren", "Jason", "John", "Justin", "Timmy", "Immanuel", "Injea", "Jonathan" };
    string[] nameComponent2 = new string[] { "Lim", "Kwak", "Park", "Po", "Simanhadi", "Kim", "Chung", "Wong" };


    // Start is called before the first frame update
    void Awake()
    {
        ServingTeam = "No ST";
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            // Move();
        }
        catch(Exception e)
        {
            Debug.LogException(e, this);
        }
    }
    // ENABLE WILL BE CALLED FIRST
    private void OnEnable()
    {
        if(!isMember)
        {
            // calculate chancetobecomemember variable and successfulsundays variable
            chanceToBecomeMember = 50f;
            successfulSundays = 100f;
            Shuffle();
            setLocation();
        }
    }

    private void OnDisable()
    {
        
    }

    private void OnMouseDown()
    {
        if (uiCanvas.activeInHierarchy)
            return;
        nameText.text = CharacterName;
        if (isMember)
        {
            isMemberText.text = "Member";
            servingTeamText.text = servingTeam;
        }
        else
        {
            isMemberText.text = "Visitor";
            servingTeamText.text = "";
        }
        skillText.text = skill;
        moodText.text = "Mood: " + mood.ToString();
        burnText.text = "Burnout: " + burnout.ToString();
        uiCanvas.SetActive(true);
    }

    public void AddSkillPoint(string skillName, float value)
    {
        if(isMember)
        {
            if (skillName == "Music")
                AddMusic(value);
            else if (skillName == "Fellowship")
                AddFellowship(value);
            else if (skillName == "Teaching")
                AddTeaching(value);
        }
    }

    /*
     * This function calculates the chance to come back the next sunday
     * This function will be called after sundays
     */
    public bool CalculateComeBackSunday()
    {
        float chance = Random.Range(0, maxChance);
        if (chance <= successfulSundays)
        {
            return true;
        }
        else
            return false;
    }

    /*
     * This function calculates th chance to become a member IF coming back is successful. 
     * This function will be called after come back sunday
     */
    public bool CalculateMemberChance()
    {
        if (Random.Range(0, maxChance) <= chanceToBecomeMember)
            return true;
        else
            return false;
    }

    public void BecomeMember()
    {
        isMember = true;
    }

    /*
     * This function will shuffle the NPC attributes such as sprites and skills.
     * This function is used when a visitor fails to come back, thus "losing" the visitor
     * and we want to reuse this game object instead of destroying it.
     */ 
    public void Shuffle()
    {
        // give new name and skill
        CharacterName = GenerateName();
        name = CharacterName;
        int randNum = Random.Range(0, 3);
        skill = skills[randNum];
        ServingTeam = "No ST";
        // recalculate chancetobecomemember variable and successfulsundays variable
    }

    public string GenerateName()
    {
        string firstName = nameComponent1[Random.Range(0, nameComponent1.Length)].ToString();
        string secondName = nameComponent2[Random.Range(0, nameComponent2.Length)].ToString();

        return firstName + " " + secondName;
    }

    // for debug purposes, will not be included later
    void setLocation()
    {
        float randX = Random.Range(-4.0f, 4.1f);
        float randY = Random.Range(-4.0f, 4.1f);
        transform.SetPositionAndRotation(new Vector3(randX, randY, 0), Quaternion.identity);
    }
}
