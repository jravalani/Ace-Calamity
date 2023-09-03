using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public UnitHealth playerHealth = new UnitHealth(5, 5);
    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Update()
    {
        CheckIfPlayerDied();
    }

    private void CheckIfPlayerDied()
    {
        if (playerHealth.Health == 0)
        {
            // game over screen
            // save game
            // load previous checkpoint
            // load coins and other stuff
            Debug.Log("GameOver");
        }
    }
}
