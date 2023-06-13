using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    private int destPoint = 0;

    void Start()
    {
        GoToNextWaypoint();
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[destPoint].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[destPoint].position) < 0.5f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
        }
    }

    void Update()
    {
        GoToNextWaypoint();
    }
}
