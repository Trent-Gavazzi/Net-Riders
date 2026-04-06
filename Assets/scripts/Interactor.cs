using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{

    public Transform interactorSource;
    public float interactRange;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.DrawRay(interactorSource.position, interactorSource.forward * interactRange, Color.red);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.GetComponentInParent<IInteractable>() is IInteractable interactObj)
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
