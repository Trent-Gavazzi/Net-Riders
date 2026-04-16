using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public Animator animator;


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float speed = new Vector2(horizontal, vertical).magnitude;

        bool isMoving = Mathf.Abs(speed) > 0.1f;
        bool isCrouching = Input.GetKey(KeyCode.LeftControl);
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isCrouching", isCrouching);
        animator.SetBool("isSprinting", isSprinting);

    }
}
