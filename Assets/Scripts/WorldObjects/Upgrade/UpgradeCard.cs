using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] private UpgradeChoice choice;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI maxText;
    [SerializeField] private TextMeshProUGUI priceText;

    private GameManager gameManager;

    private int[] maxLevels = { 5, 3, 3 };
    private int[] currLevels;

    private int[] multiplierPrice = { 0, 200, 500, 1000, 2500};
    private int[] toolPrice = { 0, 100, 800 };

    private int maxLevel;
    private int currLevel;
    private int currPrice;
        

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        maxLevel = maxLevels[(int)choice];
        UpdateData();
    }


    // Update is called once per frame
    void Update()
    {
        UpdateData();
        UpdateUI();
    }

    private void UpdateUI()
    {
        levelText.text = "Lvl. " + currLevel;
        priceText.text = currPrice + " Coins";
        if(currLevel == maxLevel)
        {
            button.interactable = false;
            button.gameObject.transform.localScale = Vector3.zero;
            priceText.text = "";
        }
        if (!CanAfford())
        {
            button.interactable = false;
            maxText.gameObject.SetActive(false);
        }
        else
        {
            button.interactable = true;
            maxText.gameObject.SetActive(true);
        }
    }

    private void UpdateData()
    {
        currLevels = gameManager.GetUpgradeLevels();
        currLevel = currLevels[(int)choice];
        if(choice == UpgradeChoice.SellMultiplier)
        {
            if(currLevel == maxLevel)
            {
                currPrice = 0;
            }
            else
            {
                currPrice = multiplierPrice[currLevel];
            }
        }
        else
        {
            if (currLevel == maxLevel)
            {
                currPrice = 0;
            }
            else
            {
                currPrice = toolPrice[currLevel];
            }
        }
    }

    private bool CanAfford()
    {
        if(gameManager.GetMoney() >= currPrice)
        {
            return true;
        }
        return false;
    }

    public void PurchaseUpgrade()
    {
        if (CanAfford())
        {
            gameManager.SetMoney(-currPrice);
            currLevel++;
            currLevel = Mathf.Clamp(currLevel, 1, maxLevel);
            if(choice == UpgradeChoice.SellMultiplier)
            {
                gameManager.currData.sellMultiplierLevel = currLevel;
            }
            else if(choice == UpgradeChoice.AxeUp)
            {
                gameManager.currData.axeLevel = currLevel;
            } 
            else if(choice == UpgradeChoice.SwordUp)
            {
                gameManager.currData.swordLevel = currLevel;
            }
        }
    }
}

internal enum UpgradeChoice
{
    SellMultiplier,
    AxeUp,
    SwordUp
}
