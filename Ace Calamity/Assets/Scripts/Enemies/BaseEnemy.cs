using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int maxHealth;
    public float moveSpeed;
    public int damage;

    protected int currentHealth;

    public PlayerBehaviour playerBehaviour;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // play death animation
        // destory gameobject
    }

}
