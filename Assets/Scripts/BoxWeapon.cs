using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWeapon : MonoBehaviour
{
	[SerializeField]
	public int weaponIndex;

	public void Awake()
	{
		weaponIndex = GameManager.instance.CountryIndex;
		//weaponIndex = 1;
		//Instantiate(weapons[weaponIndex]);
	}
}
