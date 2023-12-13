using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.MinigameActions minigame;

    private PlayerMovement playerMovement;
    private PlayerInteract playerInteract;
    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        minigame = playerInput.Minigame;

        
    }

    private void OnEnable()
    {
        minigame.Enable();
    }

    private void OnDisable()
    {
        minigame.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

}
