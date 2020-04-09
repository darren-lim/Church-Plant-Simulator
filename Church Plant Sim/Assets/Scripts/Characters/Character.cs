using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // change to private later
    [Header("Character Traits")]
    public float mood;
    public float burnout;

    [Header("Practical Skills")]
    public float Music;
    public float Fellowship;
    public float Teaching;
    [Header("Spiritual Skills")]
    public float Serving;
    public float Spirituality;


    public void Move()
    {

    }

    public void ChangeMood(float moodChange)
    {
        mood += moodChange;
    }

    public void ChangeBurnout(float burnChange)
    {
        burnout += burnChange;
    }

    public void CalculateMood()
    {

    }

    public void CalculateBurnout()
    {

    }

    public void AddMusic(float value)
    {
        if (Music < 10)
        {
            Music += value;
            if (Music > 10)
            {
                Music = 10;
            }
        }
    }
    public void AddFellowship(float value)
    {
        if (Fellowship < 10)
        {
            Fellowship += value;
            if (Fellowship > 10)
            {
                Fellowship = 10;
            }
        }
    }
    public void AddTeaching(float value)
    {
        if (Music < 10)
        {
            Music += value;
            if (Music > 10)
            {
                Music = 10;
            }
        }
    }
    public void AddServing(float value)
    {
        if (Serving < 10)
        {
            Serving += value;
            if (Serving > 10)
            {
                Serving = 10;
            }
        }
    }
    public void AddSpirit(float value)
    {
        if (Spirituality < 10)
        {
            Spirituality += value;
            if (Spirituality > 10)
            {
                Spirituality = 10;
            }
        }
    }
}
