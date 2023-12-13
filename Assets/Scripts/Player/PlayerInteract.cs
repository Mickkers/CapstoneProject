using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Vector2 actionRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, actionRange, 0, Vector2.zero);

        if (hits.Length < 1)
        {
            return;
        }

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.transform.GetComponent<Interactible>())
            {
                hit.transform.GetComponent<Interactible>().Interact();
                return;
            }
        }
    }
}
