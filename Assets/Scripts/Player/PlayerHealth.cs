using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currHealth;
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthbar;

    private GameManager gameManager;

    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        isAlive = true;
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0 && isAlive)
        {
            isAlive = false;
            gameManager.Gameover();
        }
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthbar.fillAmount = currHealth / maxHealth;
    }

    public void TakeDamage(float val)
    {
        currHealth -= val;
    }
}
