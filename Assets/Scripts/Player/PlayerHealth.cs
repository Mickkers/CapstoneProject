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

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
    }

    // Update is called once per frame
    void Update()
    {
        currHealth = Mathf.Clamp(currHealth, 0f, maxHealth);
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
        healthbar.fillAmount = currHealth / maxHealth;
    }

    public void TakeDamage(float val)
    {
        currHealth -= val;
    }
}
