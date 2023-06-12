using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
    
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        float my_health = health/maxHealth;
        healthBarUI.transform.localScale = new Vector3 (Mathf.Clamp (my_health, 0f, 1f), healthBarUI.transform.localScale.y, healthBarUI.transform.localScale.z);
    }
}
