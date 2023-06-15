using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;
    public float patrolSpeed;
    public float chaseSpeed;
    public float detectionRadius;
    public float abandonRadius;
    public float attackRadius; 
    public float attackDamage = 0.001f;

    private int destPoint = 0;
    private bool isChasing = false;
    private Player playerScript;

    private Animator animator;

    void Start()
    {
        //Debug.Log("hasVisitedGarbage is " + SceneTracker.hasVisitedGarbage);
        playerScript = player.GetComponent<Player>();
        animator = GetComponent<Animator>();
        if (SceneTracker.hasVisitedGarbage)
        {
            // spawn enemies and set them to attack the player
            GoToNextWaypoint();
        }
        
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[destPoint].position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[destPoint].position) < 0.5f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Vector3 targetPosition = player.position - directionToPlayer * 0.5f; // Adjust the multiplier as needed

        if (isChasing)
        {
            if (distanceToPlayer > abandonRadius)
            {
                isChasing = false;
                GoToNextWaypoint();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);

                if (distanceToPlayer <= attackRadius)
                {
                    playerScript.TakeDamage(attackDamage);
                    animator.SetTrigger("Attack");
                }
            }
        }
        else
        {
            Debug.Log("hasVisitedGarbage is " + SceneTracker.hasVisitedGarbage);
            if (distanceToPlayer <= detectionRadius && SceneTracker.hasVisitedGarbage)
            {
                isChasing = true;
            }
            else
            {
                GoToNextWaypoint();
            }
        }
    }

}
