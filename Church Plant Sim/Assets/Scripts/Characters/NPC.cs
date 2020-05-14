using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float chanceToBecomeMember;
    public float successfulSundays;


    // Start is called before the first frame update
    void Start()
    {
        ServingTeam = "";
        int randNum = UnityEngine.Random.Range(0, 3);
        skill = skills[randNum];

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

    private void OnEnable()
    {
        if(!isMember)
        {
            // add calculate member chance to the 
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
        return true;
    }

    /*
     * This function calculates th chance to become a member IF coming back is successful. 
     * This function will be called after come back sunday
     */
    public bool CalculateMemberChance()
    {
        // add some equation here
        return false;
    }
}
