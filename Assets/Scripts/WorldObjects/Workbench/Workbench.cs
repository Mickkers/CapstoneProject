using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workbench : Interactible
{
    [SerializeField] private Canvas workbenchUI;
    [SerializeField] private GameObject[] minigames;

    private GameplayInputManager gameplayInput;

    // Start is called before the first frame update
    void Start()
    {
        gameplayInput = FindObjectOfType(typeof(GameplayInputManager)) as GameplayInputManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        workbenchUI.gameObject.SetActive(true);
        gameplayInput.enabled = false;
    }

    public void CloseUI()
    {
        workbenchUI.gameObject.SetActive(false);
        gameplayInput.enabled = true;
    }
}
