using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkbenchMinigameManager : MonoBehaviour
{
    private int currStage;
    private Wayang result = new Wayang();

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
            CraftingComplete();
            return;
        }
        Instantiate(minigames[0], transform);
    }

    private void CraftingComplete()
    {
        GameManager gm = FindObjectOfType(typeof(GameManager)) as GameManager;
        gm.currData.wayangInventory.Add(result);

        completedMenu.gameObject.SetActive(true);
    }

    public void StageOver(float val)
    {
        result.score += (int)val;
        NextStage();
    }
}
