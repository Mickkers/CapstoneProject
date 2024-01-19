using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : Attackable
{
    [SerializeField] private int woodReward;
    [SerializeField] private float hp;
    [SerializeField] private RectTransform healthUI;
    [SerializeField] private Image healthBar;

    private float currHP;

    // Start is called before the first frame update
    void Start()
    {
        currHP = hp;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currHP == hp)
        {
            healthUI.gameObject.SetActive(false);
        }
        else
        {
            healthUI.gameObject.SetActive(true);
        }
        healthBar.fillAmount = currHP / hp;
    }

    private void CheckHP()
    {
        if (currHP <= 0)
        {
            FindObjectOfType<GameManager>().SetWood(woodReward);
            this.gameObject.SetActive(false);
        }
    }

    public override void Attack(PlayerAttack player)
    {
        if(player.GetCurrTool() == correctTool)
        {
            currHP -= player.GetAttackDamage();
        }
    }
}
