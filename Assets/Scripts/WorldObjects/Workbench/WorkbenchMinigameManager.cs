using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkbenchMinigameManager : MonoBehaviour
{
    private int currStage;
    private int wayangType;
    private float wayangScore;
    private bool minigameActive;

    [SerializeField] private GameObject[] minigames;
    [SerializeField] private TextMeshProUGUI stageText;

    private void Start()
    {
        currStage = 0;
        wayangScore = 0;
        NextStage();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if(currStage <= 3)
        {
            stageText.text = "Stage: " + currStage + "/3";
        }
        else
        {
            stageText.text = "";
        }
    }

    public void SetType(int type)
    {
        wayangType = type;
    }

    private void NextStage()
    {
        currStage++;
        if(currStage > 3)
        {
            minigameActive = false;
            CraftingComplete();
            return;
        }
        minigameActive = true;
        Instantiate(minigames[0], transform);
    }

    private void CraftingComplete()
    {
        Debug.Log("Final Wayang Score: " + wayangScore);

    }

    public void StageOver(float val)
    {
        wayangScore += val;
        NextStage();
    }
}
