using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [HideInInspector]
    public InteractableObject hoveringOverObject;
    Character hoveringOverCharacter;

    [SerializeField] UIManager uiManager;

    void Update()
    {
        CheckInteractableObject();
        if (Input.GetMouseButton(0))
        {
            if (hoveringOverObject != null)
                hoveringOverObject.Interact();
        }
    }

    private void CheckInteractableObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            UpdateInteractableObject(hit);
        }
    }

    private void UpdateInteractableObject(RaycastHit hit)
    {
        var interactableObject = hit.transform.GetComponent<InteractableObject>();
        if (interactableObject == null)
            interactableObject = hit.transform.GetComponentInParent<InteractableObject>();

        if (interactableObject != null)
        {
            hoveringOverObject = interactableObject;
            hoveringOverCharacter = hoveringOverObject.GetComponent<Character>();
            uiManager.SetTargetCharacter(hoveringOverCharacter);
        }
        else
        {
            hoveringOverObject = null;
            hoveringOverCharacter = null;
        }
    }
}
