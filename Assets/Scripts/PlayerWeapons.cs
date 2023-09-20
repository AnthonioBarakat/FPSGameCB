using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] Transform WeaponHolder;
    [SerializeField] Weapon[] weapons;
	[SerializeField] GameObject fireVFX;

    private Weapon EquipedWeapon;
    private bool isShooting;

	private PlayerBullets _playerBullets;

	private void Awake()
	{
		_playerBullets = GetComponent<PlayerBullets>();
	}

	void Update()
	{
        if (EquipedWeapon == null) return;

		if (Input.GetButtonDown("Fire1") && !isShooting) // Change "Fire1" to your desired fire button/key.
		{
			isShooting = true;
			InvokeRepeating("Fire", 0f, EquipedWeapon.fireRate);
		}

		if (Input.GetButtonUp("Fire1"))
		{
			isShooting = false;
			CancelInvoke("Fire");
		}
	}

    private void Fire()
    {
		if (_playerBullets.GetBullets() <= 0)
		{
			return;
		}

		if (EquipedWeapon != null)
		{
			EquipedWeapon.FireWeapon();
			Instantiate(fireVFX, EquipedWeapon.firePoint);
			_playerBullets.SubstractBullet(1);
		}
	}

	public void EquipWeapon(int index)
    {
        if(index < 0  || index >= weapons.Length)
        {
            Debug.LogWarning("index out of weapon range");
            return;
        }

        if (EquipedWeapon != null)
        {
            Destroy(EquipedWeapon.gameObject);
        }

        EquipedWeapon = Instantiate(weapons[index], WeaponHolder);
        EquipedWeapon.transform.position += EquipedWeapon.offset;
    }
}
