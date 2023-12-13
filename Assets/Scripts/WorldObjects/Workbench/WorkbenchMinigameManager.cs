using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchMinigameManager : MonoBehaviour
{
    private int currStage;
    private int wayangType;

    public void StartMinigame(int type)
    {
        currStage = 0;
        wayangType = type;


    }
}
