using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresCollide : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerHealthBar>().TakeDamage(2f);
		}
	}
}
