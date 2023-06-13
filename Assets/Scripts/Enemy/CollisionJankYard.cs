using UnityEngine;

public class CollisionJankYard : MonoBehaviour
{
    // Assuming the player has a tag "Player"
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneTracker.hasVisitedGarbage = true;
            Debug.Log("hasVisitedGarbage set to TRUE: ");
        }
    }
}
