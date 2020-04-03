using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // change to private later
    [Header("Character Traits")]
    public float mood;
    public float burnout;

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
}
