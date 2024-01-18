using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Podium : Interactible
{
    [SerializeField] private RectTransform podiumUI;
    [SerializeField] private RectTransform sellBox;
    [SerializeField] private TextMeshProUGUI sellAmountText;

    private GameplayInputManager gameplayInput;
    private GameManager gameManager;
    private float sellAmount;

    private readonly float[] sellMultiplier = { 1, 1.5f, 2, 2.5f, 3 };

    // Start is called before the first frame update
    void Start()
    {
        gameplayInput = FindObjectOfType<GameplayInputManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        ToggleWindow(true);
        if (gameManager.IsInventoryEmpty())
        {
            sellBox.gameObject.SetActive(false);
        }
        else
        {
            sellBox.gameObject.SetActive(true);
            sellAmount = gameManager.GetWayangValue() * sellMultiplier[gameManager.currData.sellMultiplierLevel - 1];
            sellAmountText.text = (int)sellAmount + " Coins";
        }
    }

    public void ToggleWindow(bool val)
    {
        podiumUI.gameObject.SetActive(val);
        gameplayInput.enabled = !val;
    }

    public void SellAllWayang()
    {
        gameManager.currData.wayangInventory.Clear();
        gameManager.SetMoney((int)sellAmount);
        sellAmount = 0;
        sellAmountText.text = (int)sellAmount + " Coins";
    }
}
