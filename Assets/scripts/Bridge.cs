using UnityEngine;
using  System.Collections;

public class Bridge : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 1f;
    public float distance = 5f;
    private Vector3 movementDirection = Vector3.right;

    private bool isMoving = false;


    public void Start()
    {
        
    }
    public void ActivateBridge()
    {
        if(!isMoving)
        {
            StartCoroutine(MoveBridge());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveBridge()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + movementDirection.normalized * distance;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}
