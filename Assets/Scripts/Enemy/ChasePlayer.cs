using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float detectionRadius;
    public float abandonRadius;

    private bool isChasing = false;

    void Update()
    {
        // Get the positions of the enemy and player in world coordinates
        Vector3 enemyPosition = this.transform.position;
        Vector3 playerPosition = player.position;

        // Calculate the distance between the enemy and player in world coordinates
        float distanceToPlayer = Vector3.Distance(enemyPosition, playerPosition);
        Debug.Log("Distance to Player: " + distanceToPlayer);

        if (isChasing)
        {
            Debug.Log("Chasing Player");
            if (distanceToPlayer <= abandonRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                Debug.Log("Abandoning Chase");
                isChasing = false;
            }
        }
        else
        {
            if (distanceToPlayer <= detectionRadius)
            {
                Debug.Log("Starting to Chase");
                isChasing = true;
            }
        }
    }

}
