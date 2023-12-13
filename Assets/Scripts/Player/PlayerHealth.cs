using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        UpdateHealthUI();
        if (currHealth == 0)
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        gameManager.Gameover();
    }

    private void UpdateHealthUI()
    {
        healthText.text = currHealth + "/" + maxHealth;
    }
}
