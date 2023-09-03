using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] HealthBar healthBar;
    private void Start()
    {

    }
    private void Update()
    {
        // write all the necessary code such as pressing a button to increase health and stuff
    }
    public void PlayerTakeDamage(int dmgAmount)
    {
        GameManager.gameManager.playerHealth.DamageUnit(dmgAmount);
        Debug.Log(GameManager.gameManager.playerHealth.Health);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
    }

    private void PlayerHealAmount(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }
}
