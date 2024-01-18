using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Vector2 actionRange;
    [SerializeField] private RectTransform interactPrompt;
    [SerializeField] private TextMeshProUGUI promptText;

    private Interactible interactTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CheckInteractions();
    }

    private void CheckInteractions()
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
                interactPrompt.gameObject.SetActive(true);
                interactTarget = hit.transform.GetComponent<Interactible>();
                promptText.text = interactTarget.interactPrompt;
                return;
            }
            else
            {
                interactPrompt.gameObject.SetActive(false);
                interactTarget = null;
            }
        }
    }

    public void Interact()
    {
        if(interactTarget != null)
        {
            interactTarget.Interact();
        }
    }
}
