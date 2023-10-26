using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Attackable
{
    [SerializeField] private float hp;
    [SerializeField] private EnumTools correctTool;

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
            FindObjectOfType<GameManager>().SetWood(5);
            this.gameObject.SetActive(false);
        }
    }

    public override void Attack()
    {
        hp -= 1;
        Debug.Log(hp);
    }
}
