using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAreas : Interactible
{
    [SerializeField] private EnumTeleportLocations destination;
    [SerializeField] private EnumBackgroundColors colorChoice;

    private void Start()
    {
        int choice = (int)EnumBackgroundColors.IndoorBlack;
        Debug.Log(BackgroundColors.BackgroundColor[choice]);
        choice = (int)EnumBackgroundColors.OutdoorGreen;
        Debug.Log(BackgroundColors.BackgroundColor[choice]);
    }
    public override void Interact()
    {
        FindObjectOfType<PlayerMovement>().gameObject.transform.position = TeleportLocations.Coordinates[(int)destination];
        Camera.main.backgroundColor = BackgroundColors.BackgroundColor[(int)colorChoice];
    }
}
