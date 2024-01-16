using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Attackable
{
    [SerializeField] private int woodReward;
    [SerializeField] private float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
    }

    private void CheckHP()
    {
        if (hp <= 0)
        {
            FindObjectOfType<GameManager>().SetWood(woodReward);
            this.gameObject.SetActive(false);
        }
    }

    public override void Attack(PlayerAttack player)
    {
        if(player.GetCurrTool() == correctTool)
        {
            hp -= player.GetAttackDamage();
            Debug.Log(hp);
        }
    }
}
