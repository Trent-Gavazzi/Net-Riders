using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

    void Update()
    {
        // Get the current velocity in world space
        Vector3 velocity = rb.linearVelocity;

        // Extract horizontal (X) and vertical (Y) speeds
        float horizontal = Mathf.Abs(velocity.x);
        float vertical = Mathf.Abs(velocity.y);
        float speed = new Vector2(horizontal, vertical).magnitude;

        bool isMoving = Mathf.Abs(speed) > 0.1f;
        bool isSprinting = Mathf.Abs(speed) >= 10.0f;
        
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isSprinting", isSprinting);
    }
}
