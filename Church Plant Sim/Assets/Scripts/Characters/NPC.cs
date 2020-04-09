using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public bool isMember = false;
    public string ServingTeam;


    // Start is called before the first frame update
    void Start()
    {
        ServingTeam = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
