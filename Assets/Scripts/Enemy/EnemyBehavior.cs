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

    void Start()
    {
        //Debug.Log("hasVisitedGarbage is " + SceneTracker.hasVisitedGarbage);
        playerScript = player.GetComponent<Player>();
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

        if (isChasing)
        {
            if (distanceToPlayer > abandonRadius)
            {
                isChasing = false;
                GoToNextWaypoint();
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

                if (distanceToPlayer <= attackRadius)
                {
                    playerScript.TakeDamage(attackDamage);
                }
            }
        }
        else
        {
            Debug.Log("hasVisitedGarbage is " + SceneTracker.hasVisitedGarbage);
            if (distanceToPlayer <= detectionRadius && SceneTracker.hasVisitedGarbage)
            {
                Debug.Log("Entered the if ");
                isChasing = true;
            }
            else
            {
                GoToNextWaypoint();
            }
        }
    }
}
