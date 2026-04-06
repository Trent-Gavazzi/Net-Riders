using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    //input references
    PlayerInput playerInput;// the component on the player
    InputAction moveAction; //the move in input system
    InputAction sprintAction;
    InputAction crouchAction;

    //move speeds
    public float moveSpeed = 4f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2f;

    //check to see if we are crouching or sprinting
    bool isSprinting;
    bool isCrouching;
    



    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        //Get the move settings in the input system
        moveAction = playerInput.actions.FindAction("Move");
        sprintAction = playerInput.actions.FindAction("Sprint");
        crouchAction = playerInput.actions.FindAction("Crouch");
    }

    // Update is called once per frame
    void Update()
    {
        HandleSprint();
        HandleCrouch();
        MovePlayer();
    }




    void MovePlayer(){
    Vector2 direction = moveAction.ReadValue<Vector2>();
    
    float currentSpeed = moveSpeed;

        //apply sprinting speed
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }

        //applying crouch speed
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
    //convert to 3d vector
    transform.position += new Vector3(direction.x,0,direction.y) * currentSpeed * Time.deltaTime;
    
    
    }

    //checks to see if shift is being held
    void HandleSprint()
    {
        isSprinting = sprintAction.IsPressed();
    }

    //Checks to see if ctrl is being held
    void HandleCrouch()
    {
        isCrouching = crouchAction.IsPressed();
    }
}

