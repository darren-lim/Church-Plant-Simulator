using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderChangeScript : MonoBehaviour
{
    public Slider burnoutSlider;
    public Slider moodSlider;

    public float burnVal;
    public float moodVal;
    public float maxVal;

    // Start is called before the first frame update
    void Start()
    {
        maxVal = 100f;
        burnVal = 1f;
        moodVal = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        burnVal = burnoutSlider.value;
        moodVal = moodSlider.value;
    }

    public void SetBurnoutSlider(float value)
    {
        if (value > 100)
            value = 100;
        else if (value < 0)
            value = 0;
        burnVal = value;
        burnoutSlider.value = burnVal;
    }

    public void SetMoodSlider(float value)
    {
        if (value > 100)
            value = 100;
        else if (value < 0)
            value = 0;
        moodVal = value;
        moodSlider.value = moodVal;
    }

    public float GetBurnoutValue()
    {
        return burnVal;
    }

    public float GetMoodValue()
    {
        return moodVal;
    }

    /***
    void OnDisable()
    {
        burnoutSlider.onValueChanged.RemoveAllListeners();
        moodSlider.onValueChanged.RemoveAllListeners();
    }
    ***/

}
