using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    private float xSensitivity = 30f;
    private float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float xMouse = input.x;
        float yMouse = input.y;

        // calculate camera rotation for looking up and down
        xRotation -= (yMouse * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // -80f <= x rotation <= 80f

        // apply to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //rotate player to look left and right
        transform.Rotate(Vector3.up * (xMouse * Time.deltaTime) * xSensitivity);
    }
}
