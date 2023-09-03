using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    // Fields
    int currentHealth;
    int currentMaxHealth;

    // Properties
    public int Health { get { return currentHealth; } set { currentHealth = value; } }
    public int MaxHealth { get { return currentMaxHealth; } set { currentMaxHealth = value; } }

    // Constructor
    public UnitHealth(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    // Methods
    public void DamageUnit(int damageAmount)
    {
        if (currentMaxHealth > 0)
        {
            currentHealth -= damageAmount;
        }
    }

    public void HealUnit(int healAmount)
    {
        if (currentHealth < currentMaxHealth)
        {
            currentHealth += healAmount;
        }
        if (currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
    }
}
