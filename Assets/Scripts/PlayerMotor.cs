
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    
    [SerializeField] private float speed = 5f;

    private bool isGrounded;
    private float gravity = -9.8f;

    [SerializeField] private float jumpHeight = 1.5f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // receive the inputs from InputManager.cs and apply them to the player charachter controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        // Perform gravity(Make the height of player decrease on y)
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }

    public void Crouch()
    {
        if (controller.height == 3)
            controller.height = 2;
        else if (controller.height == 2)
            controller.height = 3; // the initial height of the charachter controller
    }

    public void Sprint(bool isSprinting)
    {
        if (isSprinting)
            speed = 10;
        else 
            speed = 5;
    }
}
