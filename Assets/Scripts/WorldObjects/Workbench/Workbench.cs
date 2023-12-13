using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workbench : Interactible
{
    [SerializeField] private Canvas workbenchUI;
    [SerializeField] private RectTransform chooseTypeMenu;
    [SerializeField] private WorkbenchMinigameManager minigameManagerPrefab;

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

    public void StartMinigames(int val)
    {
        chooseTypeMenu.gameObject.SetActive(false);
        WorkbenchMinigameManager wmm = Instantiate(minigameManagerPrefab, workbenchUI.transform);
        wmm.SetType(val);
    }
}
