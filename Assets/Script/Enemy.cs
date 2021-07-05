using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public int worth = 50;
    public GameObject deathEffect; 
    public float startSpeed = 10f;
    public float distance = 0.4f;
    
    [HideInInspector]
    public float speed = 10f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
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
        PlayerStats.money += worth;
        
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }

}

