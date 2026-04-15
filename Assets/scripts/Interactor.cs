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

    void Awake()
    {
        InputSystem.Update();
    }

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
            var monos = hitInfo.collider.GetComponentsInParent<MonoBehaviour>();
            IInteractable interactable = null;

            foreach (var mono in monos)
            {
                if (mono is IInteractable i)
                {
                    interactable = i;
                    break;
                }
            }

            if (interactable != null)
            {
                currentTarget = hitInfo.collider.transform;

                if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact();
                }
            }
        }

    if (interactUI != null)
        interactUI.gameObject.SetActive(currentTarget != null);

    if (currentTarget != null)
    {
        interactUI.position = currentTarget.position + uiOffset;
    }
    }
}