using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public HealthBar healthBar;

    public GameObject lost;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            death();
        }

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void Healing(int healing)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healing;
        } 
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void death()
    {
        if (PlayerPrefs.HasKey("Heart"))
        {
            int heart = PlayerPrefs.GetInt("Heart");
            if (heart == 3)
            {
                heart = 2;
                currentHealth = maxHealth;
            }
            else if (heart == 2)
            {
                heart = 1;
                currentHealth = maxHealth;
            }
            else if (heart == 1)
            {
                heart = 0;
                currentHealth = maxHealth;
            }
            else if (heart == 0)
            {
                Destroy(gameObject);
                lost.SetActive(true);
            }
            PlayerPrefs.SetInt("Heart", heart);
        }
        else
        {
            PlayerPrefs.SetInt("Heart", 2);
        }
    }
}
