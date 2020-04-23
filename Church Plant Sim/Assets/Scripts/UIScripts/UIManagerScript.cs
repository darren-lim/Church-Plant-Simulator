using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    private void Awake()
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
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI budgetText;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void UpdateDate(string newText)
    {
        dateText.text = newText;
    }

    public void UpdateBudget(string newText)
    {
        budgetText.text = "$" + newText;
    }

}
