using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public bool isMember = false;
    public string ServingTeam;
    public string Skill;


    // Start is called before the first frame update
    void Start()
    {
        ServingTeam = "";
        Skill = "Music";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
