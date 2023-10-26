using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workbench : Interactible
{
    [SerializeField] private Canvas workbenchUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        workbenchUI.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        workbenchUI.gameObject.SetActive(false);
    }
}
