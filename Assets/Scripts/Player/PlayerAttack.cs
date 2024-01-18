using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Header("Interaction & Attack Settings")]
    [SerializeField] private Vector2 actionRange;
    [SerializeField] private float attackCooldown;
    [SerializeField] private EnumTools currTool;
    [SerializeField] private Image toolUI;
    [SerializeField] private Sprite[] axeIcons;
    [SerializeField] private Sprite[] swordIcons;
    [SerializeField] private Sprite scytheIcon;
    [SerializeField] private Animator effectAnim;

    private GameManager gameManager;

    private bool canAttack;
    private bool isAttacking;

    private readonly int[] toolDamage = { 1, 2, 5 };

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        canAttack = true;
        currTool = EnumTools.Axe;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack()
    {
        if (canAttack && !isAttacking)
        {
            StartCoroutine(AttackAction());
        }
    }

    private IEnumerator AttackAction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, actionRange, 0, Vector2.zero);
        if (hits.Length < 1)
        {
            yield return new WaitForSeconds(0);
        }
        else
        {
            canAttack = false;
            isAttacking = true;
            effectAnim.SetTrigger(AnimationStrings.attack);

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.GetComponent<Attackable>())
                {
                    hit.transform.GetComponent<Attackable>().Attack(this);
                }
            }

            yield return new WaitForSeconds(attackCooldown);
            isAttacking = false;
            canAttack = true;
        }
    }
    public void NextTool()
    {
        if (currTool == EnumTools.Axe)
        {
            currTool = EnumTools.Scythe;
            toolUI.sprite = scytheIcon;
        }
        else if (currTool == EnumTools.Scythe)
        {
            currTool = EnumTools.Sword;
            toolUI.sprite = swordIcons[gameManager.currData.swordLevel - 1];
        }
        else if (currTool == EnumTools.Sword)
        {
            currTool = EnumTools.Axe;
            toolUI.sprite = axeIcons[gameManager.currData.axeLevel - 1];
        }
    }

    public void PrevTool()
    {
        if (currTool == EnumTools.Axe)
        {
            currTool = EnumTools.Sword;
            toolUI.sprite = swordIcons[gameManager.currData.swordLevel - 1];
        }
        else if (currTool == EnumTools.Scythe)
        {
            currTool = EnumTools.Axe;
            toolUI.sprite = axeIcons[gameManager.currData.axeLevel - 1];
        }
        else if (currTool == EnumTools.Sword)
        {
            currTool = EnumTools.Scythe;
            toolUI.sprite = scytheIcon;
        }
    }
    public int CurrToolLevel()
    {
        if (currTool == EnumTools.Axe)
        {
            return gameManager.currData.axeLevel;
        }
        else if (currTool == EnumTools.Sword)
        {
            return gameManager.currData.swordLevel;
        }
        return 1;
    }

    public float GetAttackDamage()
    {
        return toolDamage[CurrToolLevel() - 1];
    }

    public EnumTools GetCurrTool()
    {
        return currTool;
    }
}
