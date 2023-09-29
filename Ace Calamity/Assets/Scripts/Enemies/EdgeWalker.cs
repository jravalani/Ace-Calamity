using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeWalker : BaseEnemy
{
    // public Vector2 raycastOffset = new Vector2(2f, 0f);
    // [SerializeField] int rayLength;
    // [SerializeField] LayerMask Ground;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        /*   Vector2 raycastStart = (Vector2)transform.position + raycastOffset;
           RaycastHit2D downwardRay = Physics2D.Raycast(raycastStart, Vector2.down, rayLength, Ground);
           Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.green);

           if (downwardRay.collider == null)
           {
               transform.Rotate(Vector3.forward, 90);
           }  */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.Rotate(Vector3.forward, -90f);
        //transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerBehaviour.PlayerTakeDamage(damage);
        }
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
}
