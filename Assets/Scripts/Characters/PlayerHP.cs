using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private float health;
    private float maxHealth;

    private Transform player;
    private PlayerHealth playerHealth;
    private HealthBar healthBar;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>(); 
        healthBar = GetComponent<HealthBar>();
    }

    void Update()
    {
        health = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;

        healthBar.UpdateBar(health, maxHealth);
    }
}
