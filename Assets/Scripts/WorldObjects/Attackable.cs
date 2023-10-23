using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Attackable : MonoBehaviour
{
    public abstract void Attack();
}
