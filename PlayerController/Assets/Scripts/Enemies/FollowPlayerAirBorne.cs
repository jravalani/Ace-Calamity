using UnityEngine;

public class FollowPlayerAirBorne : BaseEnemy
{
    Rigidbody2D rb;
    public float detectionRadius = 10f;
    public float avoidanceRadius = 1f;
    public float avoidanceStrength = 0.5f;
    public LayerMask obstacleLayer; // Assign the obstacle layer in the Inspector

    Transform player;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(rb.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 moveDirection = (player.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            // play idle animation
            rb.velocity = Vector2.zero;

        }
    }
}
