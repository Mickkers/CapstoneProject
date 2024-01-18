using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.GameplayActions gameplay;

    private PlayerMovement playerMovement;
    private PlayerInteract playerInteract;
    private PlayerAttack playerAttack;
    private GameplayUIManager gameplayUIManager;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        gameplay = playerInput.Gameplay;
        playerMovement = GetComponent<PlayerMovement>();
        playerInteract = GetComponent<PlayerInteract>();
        playerAttack = GetComponent<PlayerAttack>();
        gameplayUIManager = FindObjectOfType<GameplayUIManager>();

        gameplay.Interact.performed += ctx => playerInteract.Interact();
        gameplay.Attack.performed += ctx => playerAttack.Attack();
        gameplay.PrevTool.performed += ctx => playerAttack.PrevTool();
        gameplay.NextTool.performed += ctx => playerAttack.NextTool();
        gameplay.Pause.performed += ctx => gameplayUIManager.TogglePause(true);
    }

    private void OnEnable()
    {
        gameplay.Enable();
    }

    private void OnDisable()
    {
        gameplay.Disable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        playerMovement.Movement(gameplay.Move.ReadValue<Vector2>());
    }

    public static Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }
}
