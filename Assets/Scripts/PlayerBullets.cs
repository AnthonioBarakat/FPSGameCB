
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullets : MonoBehaviour
{
	private int bullets;
	private int maxBullets = 100;
	public Image frontBullet;

	public GameObject bulletsGenerator;

	private void Awake()
	{
		bulletsGenerator = GameObject.FindWithTag("Bullets");
	}

	void Start()
	{
		bullets = 0;
	}

	void Update()
	{
		//UpdateBullets();
		
		if (Input.GetKeyDown(KeyCode.L))
		{
			SubstractBullet(10);
		}
	}

	public int GetBullets() => bullets;

	public void UpdateBullets()
	{
		float bulletFraction = (float) bullets / maxBullets;

		frontBullet.fillAmount = bulletFraction;
	}

	public void RestoreBullet(int bulletNumber)
	{
		bullets += bulletNumber;
		if (bullets > 100)
			bullets = 100;
		UpdateBullets();
	}

	public void SubstractBullet(int bulletNumber)
	{
		bullets -= bulletNumber;
		if (bullets < 0)
			bullets = 0;
		UpdateBullets();
	}
}
