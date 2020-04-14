using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BudgetScript : MonoBehaviour
{
    [Header("Budget Attributes")]
    public float TotalMoney = 1000f;
    public float WeeklyRevenue = 0f;
    public float BaseWeeklyProfit = 500f;
    public bool hasBeenBailed = false;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onSundayEvent += ResetWeek;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMoney(float money)
    {
        TotalMoney += money;
        WeeklyRevenue += money;
        budgetUIUpdate();
    }

    public void SubtractMoney(float money)
    {
        TotalMoney -= money;
        WeeklyRevenue -= money;

        if (TotalMoney < 0 && !hasBeenBailed)
        {
            // we want to let the player know they have no money
            // but they can be bailed out
        }
        else if (TotalMoney < 0 && hasBeenBailed)
        {
            // if they do not make enough by the end of the week
            // game over
        }

        budgetUIUpdate();
    }

    public void ResetWeek()
    {
        WeeklyRevenue = 0f;
        TotalMoney += BaseWeeklyProfit;
        budgetUIUpdate();
    }

    public void budgetUIUpdate()
    {
        UIManagerScript.instance.UpdateBudget(TotalMoney.ToString());
    }

    public float returnMoney()
    {
        return TotalMoney;
    }

    public void bailedOut()
    {
        hasBeenBailed = true;
    }
}
