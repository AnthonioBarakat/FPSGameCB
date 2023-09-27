
using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    private float xSensitivity = 30f;
    private float ySensitivity = 30f;

	private void Start()
	{
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

	public void ProcessLook(Vector2 input)
    {
        float xMouse = input.x;
        float yMouse = input.y;

        // calculate camera rotation for looking up and down
        xRotation -= (yMouse * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f,90f); // -80f <= x rotation <= 80f

        // apply to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //Debug.Log(weapon.ToString());
        //weapon.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (xMouse * Time.deltaTime) * xSensitivity);
    }
}
