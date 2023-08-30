using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private float health;
    private float maxHealth = 100f;
    //private float delayRate = 12f;
    //private float lerpTimer;

    public Image frontHealth, backHealth;

    public Text healthText;


    private void Awake()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealth();

        // for testing onyl
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(7f);
        }
    }

    public void UpdateHealth()
    {
        // destroy player if health 0 or less
        if (health <= 0)
        {
            Destroy(gameObject);
        }



        // keep the value between 0 and 1(for fill image value)
        float healthFraction = health / maxHealth;
        float fillF = frontHealth.fillAmount;
        float fillB = backHealth.fillAmount;

        // check if fillB has value more than healthFraction => that mean take damage
        if (healthFraction < fillB)
        {
            frontHealth.fillAmount = healthFraction;

            //lerpTimer += Time.deltaTime;
            //float delayTime = lerpTimer / delayRate;

            // the lerp function will change value from one point to another during a period of time
            backHealth.fillAmount = Mathf.Lerp(fillB, healthFraction, 0.009f);
            healthText.text = health.ToString();

        }

        // check if fillB has value less than healthFraction => that mean take restore life
        if (healthFraction > fillB)
        {
            frontHealth.fillAmount = healthFraction;
            backHealth.fillAmount = healthFraction;

            healthText.text = health.ToString();

        }
    }



    public void RestoreHealth()
    {
        health += 50;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

    }
}
