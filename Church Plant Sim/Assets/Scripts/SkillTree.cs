using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : Skills
{
    public static SkillTree instance;
    public Skills skillset;
    void Awake()
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
    void Start()
    {
        skillset = new Skills(1f, 1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSkill(string skillName, float value)
    {
        if (skillName == "Music")
            skillset.AddMusic(value);
        else if (skillName == "Fellowship")
            skillset.AddFellowship(value);
        else if (skillName == "Teaching")
            skillset.AddTeaching(value);
        else if (skillName == "Serving")
            skillset.AddServing(value);
        else if (skillName == "Spirituality")
            skillset.AddSpirit(value);
    }

}
