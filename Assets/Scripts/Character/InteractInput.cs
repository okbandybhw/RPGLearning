using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI textOnScreen;
    [HideInInspector]
    public InteractableObject hoveringOverObject;
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
            var interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject == null)
                interactableObject = hit.transform.GetComponentInParent<InteractableObject>();

            if (interactableObject != null)
            {
                hoveringOverObject = interactableObject;
                textOnScreen.text = interactableObject.transform.name;
            }
            else
            {
                hoveringOverObject = null;
                textOnScreen.text = "";
            }
        }
    }
}
