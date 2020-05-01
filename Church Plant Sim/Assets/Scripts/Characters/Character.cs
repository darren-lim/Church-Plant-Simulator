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

    [Header("Max Amount of Skill Points")]
    public float maxPoints;

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
        if (Music < maxPoints)
        {
            Music += value;
            if (Music > maxPoints)
            {
                Music = maxPoints;
            }
        }
    }
    public void AddFellowship(float value)
    {
        if (Fellowship < maxPoints)
        {
            Fellowship += value;
            if (Fellowship > maxPoints)
            {
                Fellowship = maxPoints;
            }
        }
    }
    public void AddTeaching(float value)
    {
        if (Teaching < maxPoints)
        {
            Teaching += value;
            if (Teaching > maxPoints)
            {
                Teaching = maxPoints;
            }
        }
    }
    public void AddServing(float value)
    {
        if (Serving < maxPoints)
        {
            Serving += value;
            if (Serving > maxPoints)
            {
                Serving = maxPoints;
            }
        }
    }
    public void AddSpirit(float value)
    {
        if (Spirituality < maxPoints)
        {
            Spirituality += value;
            if (Spirituality > maxPoints)
            {
                Spirituality = maxPoints;
            }
        }
    }

    public float GetMaxPoints()
    {
        return maxPoints;
    }
}
