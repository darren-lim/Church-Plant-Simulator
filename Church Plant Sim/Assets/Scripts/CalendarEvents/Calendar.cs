using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar instance;
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
    public Date currDate;
    // Start is called before the first frame update
    void Start()
    {
        currDate = new Date(1, 1, 2000);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextDay()
    {
        currDate.AddOneDay();
        Debug.Log(currDate.ToString());
    }
}
