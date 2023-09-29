using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFroEnemy : BaseEnemy
{
    Rigidbody2D rb;
    float originalMoveSpeed;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        originalMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // GameManager.gameManager.playerHealth.DamageUnit(damage);
            playerBehaviour.PlayerTakeDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);

        // Add any specific behavior for taking damage by this enemy
        // For example, play a hit animation, play a sound, etc.
    }

    public override void Die()
    {
        // Add any specific behavior for when this enemy is defeated
        // For example, play a death animation, play a sound, drop items, etc.

        // Then destroy the enemy GameObject
        Destroy(gameObject);
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), 1f);
    }
}
