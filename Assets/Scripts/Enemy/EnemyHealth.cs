using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Attackable
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthbar;


    private float currHealth;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealth()
    {
        if (currHealth <= 0f && isAlive)
        {
            isAlive = false;
            StartCoroutine(Death());
        }
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthbar.fillAmount = currHealth / maxHealth;
    }

    private IEnumerator Death()
    {

        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }

    public override void Attack(PlayerAttack player)
    {
        if(player.GetCurrTool() == correctTool)
        {
            currHealth -= player.GetAttackDamage();
        }
        else
        {
            currHealth -= 1;
        }
    }
}
