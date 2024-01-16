using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactible : MonoBehaviour
{
    public string interactPrompt;
    public abstract void Interact();
}
