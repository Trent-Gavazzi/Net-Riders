using UnityEngine;

public class CameraClicker : MonoBehaviour
{

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from the camera to the mouse position
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // Perform the raycast
            {
                Clickable clickable = hit.collider.GetComponent<Clickable>(); // Check if the hit object has a ClickableObject component
                if (clickable != null)
                {
                    clickable.OnClick(); // Call the OnClick method
                }
            }
        }
    }
}
