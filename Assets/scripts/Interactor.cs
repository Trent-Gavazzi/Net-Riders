using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;

    public Transform interactUI;
    public Vector3 uiOffset = new Vector3(0, 2f, 0);

    private Transform currentTarget;

    void Start()
    {
        if (interactUI != null)
            interactUI.gameObject.SetActive(false);
    }

    void Update()
    {
        currentTarget = null;

        Ray ray = new Ray(interactorSource.position, interactorSource.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
        {
            var interactable = hitInfo.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                currentTarget = hitInfo.collider.transform;

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact();
                }
            }
        }

        // Show/hide UI
        if (interactUI != null)
            interactUI.gameObject.SetActive(currentTarget != null);

        // Move UI in world space
        if (currentTarget != null)
        {
            interactUI.position = currentTarget.position + uiOffset;
        }
    }
}