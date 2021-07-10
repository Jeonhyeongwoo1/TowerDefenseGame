using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startHealth = 200f;
    public int worth = 50;
    public GameObject deathEffect; 
    public float startSpeed = 10f;
    public float distance = 0.4f;
    
    [HideInInspector]
    public float speed = 10f;

    [Header("Unity Stuff")]
    public Image healthBar;

    private float health;
    private bool isDead = false;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 200f;

        if(health <= 0f && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed  = startSpeed * (1f - amount);    
    }

    void Die()
    {
        isDead = true;
        PlayerStats.money += worth;
        
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }

}

