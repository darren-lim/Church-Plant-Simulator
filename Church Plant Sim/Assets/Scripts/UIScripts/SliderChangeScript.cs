using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderChangeScript : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public TextMeshProUGUI s1Percent;
    public TextMeshProUGUI s2Percent;

    public float s1Val;
    public float s2Val;
    public float maxVal;

    // Start is called before the first frame update
    void Start()
    {
        maxVal = 100f;
        s1Val = 50f;
        s2Val = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        s1Val = slider1.value;
        s2Val = slider2.value;

        slider1.onValueChanged.AddListener(ChangeSermonValue);
        ChangeSermonValue(slider1.value);

        slider2.onValueChanged.AddListener(ChangeClassValue);
        ChangeClassValue(slider2.value);
    }

    void OnDisable()
    {
        slider1.onValueChanged.RemoveAllListeners();
        slider2.onValueChanged.RemoveAllListeners();
    }

    private void ChangeSermonValue(float value)
    {
        s1Percent.text = value.ToString() + "%";
        float oppositeVal = maxVal - value;
        s2Percent.text = oppositeVal.ToString() + "%";
        slider2.value = oppositeVal;
    }

    private void ChangeClassValue(float value)
    {
        s2Percent.text = value.ToString() + "%";
        float oppositeVal = maxVal - value;
        s1Percent.text = oppositeVal.ToString() + "%";
        slider1.value = oppositeVal;

    }
}
