using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDanScript : Character
{
    public static PDanScript instance;
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
        Music = 0f;
        Fellowship = 0f;
        Teaching = 0f;
        Spirituality = 0f;
        Serving = 0f;
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

    public float GetMusic()
    {
        return Music;
    }

    public float GetFellowship()
    {
        return Fellowship;
    }

    public float GetTeaching()
    {
        return Teaching;
    }

    public float GetServing()
    {
        return Serving;
    }

    public float GetSpirituality()
    {
        return Spirituality;
    }
}
