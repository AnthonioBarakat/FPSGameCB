
using UnityEngine;

using UnityEngine.InputSystem; // ^^

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;


    private PlayerMotor motor;

    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.onFoot;

        motor = GetComponent<PlayerMotor>();

        look = GetComponent<PlayerLook>();

        // add event to jump when performed[start-performed-canceled]
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Crouch.performed += ctx => motor.Crouch();

        onFoot.Sprint.performed += ctx => motor.Sprint(true);
        onFoot.Sprint.canceled += ctx => motor.Sprint(false);
    }

    void FixedUpdate()
    {
        // tell the player motor to move using the value from movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
		look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
	}


	private void LateUpdate()
    {
        //look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }

}
