using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
	private Transform mainCameraTransform;

	private void Start()
	{
		// Find the main camera in the scene.
		mainCameraTransform = Camera.main.transform;
	}

	private void LateUpdate()
	{
		// Rotate the Canvas to always face the camera.
		transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
	}
}
