
using UnityEngine;

public class BoxWeapon : MonoBehaviour
{
	[SerializeField]
	public int weaponIndex;

	public void Start()
	{
		GameManager gameManager = GameManager.instance;
		if (gameManager != null )
			weaponIndex = gameManager.CountryIndex;

		//weaponIndex = 1;
		//Instantiate(weapons[weaponIndex]);
	}
}
