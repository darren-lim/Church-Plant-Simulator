using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [Header("Practical Skills")]
    public float Music;
    public float Fellowship;
    public float Teaching;
    [Header("Spiritual Skills")]
    public float Serving;
    public float Spirituality;

    // Max Skill Level is 10?

    public Skills()
    {
        Music = 0f;
        Fellowship = 0f;
        Teaching = 0f;
        Serving = 0f;
        Spirituality = 0f;
    }

    public Skills(float musicVal, float fellVal, float teachVal, float serveVal, float spiritVal)
    {
        Music = musicVal;
        Fellowship = fellVal;
        Teaching = teachVal;
        Serving = serveVal;
        Spirituality = spiritVal;
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
