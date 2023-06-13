using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;

    private void Start()
    {
        PickNewDirection();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;

        // If the player has moved in the chosen direction for 2 seconds, pick a new direction
        if (Time.time % 2 < 0.1f)
        {
            PickNewDirection();
        }
    }

    private void PickNewDirection()
    {
        // Choose a random direction
        direction = Random.insideUnitCircle.normalized;
    }
}
