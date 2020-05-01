using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public Slider musicSlider;
    public Slider fellowSlider;
    public Slider teachSlider;
    public Slider spiritSlider;
    public Slider servingSlider;

    private Slider[] sliders;

    private PDanScript pDan;

    // Start is called before the first frame update
    void Start()
    {
        sliders = new Slider[] { musicSlider, fellowSlider, teachSlider, spiritSlider, servingSlider };
        pDan = PDanScript.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].maxValue = pDan.GetMaxPoints();
        }
        musicSlider.value = pDan.GetMusic();
        fellowSlider.value = pDan.GetFellowship();
        teachSlider.value = pDan.GetTeaching();
        spiritSlider.value = pDan.GetSpirituality();
        servingSlider.value = pDan.GetServing();
    }

}
