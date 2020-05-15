using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Character
{
    [Header("NPC Attributes")]
    public string skill;
    public Date dateJoined;
    // if is member is false, then we are visitor
    public bool isMember = false;
    public string CharacterName;

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
        ServingTeam = "";
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
        }
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy()
    {
        // destory only when npc is visitor and it has
        // failed to come back the next sunday
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

    /*
     * This function will shuffle the NPC attributes such as sprites and skills.
     * This function is used when a visitor fails to come back, thus "losing" the visitor
     * and we want to reuse this game object instead of destroying it.
     */ 
    public void Shuffle()
    {
        // give new name and skill
        name = GenerateName();
        int randNum = Random.Range(0, 3);
        skill = skills[randNum];
        // recalculate chancetobecomemember variable and successfulsundays variable
    }

    public string GenerateName()
    {
        string firstName = nameComponent1[Random.Range(0, nameComponent1.Length)].ToString();
        string secondName = nameComponent2[Random.Range(0, nameComponent2.Length)].ToString();

        return firstName + " " + secondName;
    }
}
