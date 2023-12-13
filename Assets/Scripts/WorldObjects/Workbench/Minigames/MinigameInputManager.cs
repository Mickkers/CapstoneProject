using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.MinigameActions minigame;

    private Minigame mgame;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        minigame = playerInput.Minigame;
        mgame = GetComponent<Minigame>();
        
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
        mgame.MinigameDirectional(minigame.Directional.ReadValue<Vector2>());
    }

}
