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
    public string[] skills = new string[3] { "Music", "Fellowship", "Teaching" };

    [Header("Spiritual Skills")]
    public float Serving;
    public float Spirituality;

    [Header("Max Amount of Skill Points")]
    public float maxPoints;

    [Header("Animations / Moving")]
    public Animator animator;
    public Transform[] movePoints;
    protected bool AtPoint = true;
    private int listIndex = 0;
    protected Vector3 point;
    public float moveSpeed = 1f;
    public float waitTime = 2f;
    public float MoveTime = 10f;
    public float MoveTimeMax = 10f;

    public IEnumerator Move()
    {
        while(Application.isPlaying)
        {
            if (AtPoint)
            {
                listIndex++;
                if (listIndex == movePoints.Length)
                    listIndex = 0;
                point = new Vector3(movePoints[listIndex].position.x, movePoints[listIndex].position.y);
                animator.SetBool("walkUp", false);
                animator.SetBool("walkDown", false);
                animator.SetBool("walkRight", false);
                animator.SetBool("walkLeft", false);
                animator.SetBool("isIdle", true);
                AtPoint = false;
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                animator.SetBool("isIdle", false);
                transform.position = Vector3.MoveTowards(transform.position, point, moveSpeed * Time.deltaTime);
                Vector3 heading = point - transform.position;
                // walk right
                if (heading.x > 0)
                {
                    if (heading.y > heading.x)
                    {
                        // if walking more up than right, set animation up
                        animator.SetBool("walkUp", true);
                        animator.SetBool("walkRight", false);
                    }
                    else if (heading.y < -heading.x)
                    {
                        animator.SetBool("walkDown", true);
                        animator.SetBool("walkRight", false);
                    }
                    else
                    {
                        animator.SetBool("walkRight", true);
                    }
                }
                // walk left
                else
                {
                    if (heading.y < heading.x)
                    {
                        animator.SetBool("walkDown", true);
                        animator.SetBool("walkLeft", false);
                    }
                    else if (heading.y > -heading.x)
                    {
                        animator.SetBool("walkUp", true);
                        animator.SetBool("walkLeft", false);
                    }
                    else
                    {
                        animator.SetBool("walkLeft", true);
                    }
                }
                MoveTime--;
                if (MoveTime <= 0)
                {
                    if (Vector3.Distance(transform.position, point) < 0.001f)
                    {
                        AtPoint = true;
                        MoveTime = MoveTimeMax;
                    }
                }
                yield return null;
            }
        }
        yield return null;
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
