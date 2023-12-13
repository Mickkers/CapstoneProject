using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Attackable : MonoBehaviour
{
    public EnumTools correctTool;

    public abstract void Attack(PlayerAttack player);
}
