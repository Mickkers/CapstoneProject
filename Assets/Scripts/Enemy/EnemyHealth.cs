using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Attackable
{
    [SerializeField] private int leatherReward;

    [SerializeField] private float maxHealth;
    [SerializeField] private RectTransform healthUI;
    [SerializeField] private Image healthbar;



    private float currHealth;
    [HideInInspector] public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
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
        if(currHealth == maxHealth)
        {
            healthUI.gameObject.SetActive(false);
        }
        else
        {
            healthUI.gameObject.SetActive(true);
        }
        healthbar.fillAmount = currHealth / maxHealth;
    }

    private IEnumerator Death()
    {
        GameManager gm = FindObjectOfType(typeof(GameManager)) as GameManager;
        gm.SetLeather(leatherReward);
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
