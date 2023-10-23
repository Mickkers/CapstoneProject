using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactible : MonoBehaviour
{
    public abstract void Interact();
}
