using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This script controls the main budgeting system in the game. 
 */

public class BudgetScript : MonoBehaviour
{
    [Header("Budget Attributes")]
    public float TotalMoney = 1000f;
    public float WeeklyRevenue = 0f;
    public float BaseWeeklyProfit = 500f;
    public float TitheProfit = 0f;
    public bool hasBeenBailed = false;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onWeekdayStartEvent += ResetWeek;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMoney(float money)
    {
        TotalMoney += money;
        WeeklyRevenue += money;
        BudgetUIUpdate();
    }

    public void AddTithe(float money)
    {
        TitheProfit += money;
        AddMoney(money);
        Debug.Log("Today's tithe: " + TitheProfit.ToString());
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

        BudgetUIUpdate();
    }

    public void ResetWeek()
    {
        WeeklyRevenue = 0f;
        TotalMoney += BaseWeeklyProfit;
        TitheProfit = 0f;
        BudgetUIUpdate();
    }

    public void BudgetUIUpdate()
    {
        UIManagerScript.instance.UpdateBudget(TotalMoney.ToString());
    }

    public float ReturnMoney()
    {
        return TotalMoney;
    }

    public void BailedOut()
    {
        hasBeenBailed = true;
    }
}
