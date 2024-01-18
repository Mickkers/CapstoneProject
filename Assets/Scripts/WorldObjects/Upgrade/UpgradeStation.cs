using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStation : Interactible
{
    [SerializeField] private RectTransform upgradeUI;

    private GameplayInputManager gameplayInput;

    // Start is called before the first frame update
    void Start()
    {
        gameplayInput = FindObjectOfType<GameplayInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void Interact()
    {
        ToggleWindow(true);
    }

    public void ToggleWindow(bool val)
    {
        upgradeUI.gameObject.SetActive(val);
        gameplayInput.enabled = !val;
    }
}
