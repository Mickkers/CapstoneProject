using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CraftCard : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI costText;

    private Workbench workbench;
    private GameManager gameManager;

    [SerializeField] private bool isWood;

    private int woodCost;
    private int leatherCost;


    // Start is called before the first frame update
    void Start()
    {
        workbench = FindObjectOfType<Workbench>();
        gameManager = FindObjectOfType<GameManager>();
        if (isWood)
        {
            woodCost = workbench.cost1;
            leatherCost = workbench.cost2;
        }
        else
        {
            woodCost = workbench.cost2;
            leatherCost = workbench.cost1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private bool CanAfford()
    {
        if(gameManager.GetWood() >= woodCost && gameManager.GetLeather() >= leatherCost)
        {
            return true;
        }
        return false;
    }

    private int WayangType()
    {
        if (isWood)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    private void UpdateUI()
    {
        costText.text = "Cost:\n" + woodCost + " Wood\n" + leatherCost + " Leather";
        if (!CanAfford())
        {
            button.interactable = false;
            button.image.color = new Color(1, 1, 1, 0.7f);
        }
        else
        {
            button.interactable = true;
            button.image.color = new Color(1, 1, 1, 1);
        }
    }

    public void StartMinigame()
    {
        if (CanAfford())
        {
            gameManager.SetWood(-woodCost);
            gameManager.SetLeather(-leatherCost);
            workbench.StartMinigames(WayangType());
        }
    }
}
