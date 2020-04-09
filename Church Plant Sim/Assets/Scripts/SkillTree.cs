using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : PDanScript
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSkill(string skillName, float value)
    {
        if (skillName == "Music")
            AddMusic(value);
        else if (skillName == "Fellowship")
            AddFellowship(value);
        else if (skillName == "Teaching")
            AddTeaching(value);
        else if (skillName == "Serving")
            AddServing(value);
        else if (skillName == "Spirituality")
            AddSpirit(value);
    }

}
