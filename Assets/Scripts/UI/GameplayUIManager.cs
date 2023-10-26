using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text monthDate;
    [SerializeField] private TMP_Text time;
    [SerializeField] private TMP_Text money;
    [SerializeField] private TMP_Text resources;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        monthDate.text = "Month: " + gameManager.GetMonth() + " Date: " + gameManager.GetDate();
        time.text = gameManager.GetTime();
        money.text = gameManager.GetMoney().ToString();
        resources.text = "Wood: " + gameManager.GetWood() + " Leather: " + gameManager.GetLeather();
    }
}
