using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudgetScript : MonoBehaviour
{
    public float TotalMoney = 1000f;
    public float WeeklyRevenue = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMoney(float money)
    {
        TotalMoney += money;
        WeeklyRevenue -= money;
    }

    public void SubtractMoney(float money)
    {
        TotalMoney -= money;
        WeeklyRevenue -= money;
    }

    public void NewWeek()
    {
        WeeklyRevenue = 0f;
    }

    public float returnMoney()
    {
        return TotalMoney;
    }
}
