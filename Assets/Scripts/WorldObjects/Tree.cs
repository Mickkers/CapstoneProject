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
        
    }

    public override void Attack()
    {
        hp -= 1;
    }
}
