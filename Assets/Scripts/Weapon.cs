
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Vector3 offset;
	public float fireRate;

	[SerializeField] float damage;

	public Transform firePoint;


	public void FireWeapon()
	{
		// Get the center of the screen in world coordinates.
		Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

		// Cast a ray from the weapon firepoint to the center of the screen.
		Ray ray = Camera.main.ScreenPointToRay(screenCenter);
		RaycastHit hit;


		if (Physics.Raycast(ray, out hit))
		{
			// Check if the ray hits something (e.g., an enemy).
			// You can add logic here to handle the hit object.
			Debug.DrawLine(firePoint.position, hit.point, Color.red, 1f); // Draw a debug line to visualize the raycast.

			var enemy = hit.transform.GetComponent<Enemy>();
			if(enemy) enemy.ChangeHealth(-damage);
		}
		else
		{
			// The ray didn't hit anything. You can add logic for a miss.
		}
	}
}
