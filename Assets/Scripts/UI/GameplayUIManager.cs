using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text monthDate;
    [SerializeField] private TMP_Text time;
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
        monthDate.text = gameManager.GetDate().ToString();
        time.text = gameManager.GetTime();
        resources.text = "Money: \n" + gameManager.GetMoney() + "\nWood: \n" + gameManager.GetWood() + "\nLeather: \n" + gameManager.GetLeather();
    }
}
