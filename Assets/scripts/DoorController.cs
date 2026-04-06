using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorController : MonoBehaviour
{
    public float rotationAngle = 90f;     // Degrees to rotate
    public float rotationSpeed = 2f;      // Speed of rotation

    private bool isOpening = false;
    private Quaternion startRotation;
    private Quaternion targetRotation;

    void Start()
    {
        startRotation = transform.localRotation;
        targetRotation = startRotation * Quaternion.Euler(-rotationAngle, 0f, 0f); // Clockwise on X
    }

    void Update()
    {
        if (isOpening)
        {
            transform.localRotation = Quaternion.Slerp(
                transform.localRotation,
                targetRotation,
                Time.deltaTime * rotationSpeed
            );

            // Stop when close enough
            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
            {
                transform.localRotation = targetRotation;
                isOpening = false;
            }
        }
    }


    public void openDoor()
    {
        isOpening = true;
    }
}
