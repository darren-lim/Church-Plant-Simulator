using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour
{
    public Sprite[] StagesSprites;

    void Start()
    {

    }

    public Sprite returnStage(int stageNum)
    {
        return StagesSprites[stageNum];
    }
}
