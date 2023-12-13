using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkbenchMinigameManager : MonoBehaviour
{
    private int currStage;
    private Wayang result = new Wayang();
    private bool minigameActive;

    [SerializeField] private GameObject[] minigames;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private Transform completedMenu;

    private void Start()
    {
        currStage = 0;
        result.score = 0;
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
        result.type = type;
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
        SaveManager sm = FindObjectOfType(typeof(SaveManager)) as SaveManager;
        sm.gameData.wayangInventory.Add(result);

        completedMenu.gameObject.SetActive(true);
    }

    public void StageOver(float val)
    {
        result.score += (int)val;
        NextStage();
    }
}
