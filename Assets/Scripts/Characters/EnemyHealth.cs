using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public HealthBar healthBar;

    public UnityEvent onDeath;

    private void OnEnable()
    {
        onDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        onDeath.RemoveListener(Death);
    }

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
            onDeath.Invoke();
        }

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void Death()
    {
        Reward reward = GetComponent<Reward>();
        if (reward != null)
        {
            reward.RewardItem();
        }
        Destroy(gameObject);
    }
}
