using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public PlayerBehaviour playerBehaviour;
    public int healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerBehaviour.PlayerHealAmount(healAmount);
            // destruction animation
            Invoke("DestroyHealObject", 1f);
        }
    }

    private void DestroyHealObject()
    {
        Destroy(gameObject);
    }
}
