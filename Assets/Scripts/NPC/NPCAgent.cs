using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class NPCAgent : Agent
{
    private Rigidbody2D rb;
    public Transform playerTransform;  // You need to assign this in the Unity Inspector

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        // Reset the NPC's position and velocity
        this.transform.localPosition = Vector3.zero;
        rb.velocity = Vector2.zero;

        // You can add more code here to reset the game or NPC state at the start of each episode
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Collect relative position of the player to the NPC
        sensor.AddObservation(playerTransform.localPosition - this.transform.localPosition);
        
        // If there are obstacles or other features the NPC should be aware of, add those observations here
    }

public override void OnActionReceived(ActionBuffers actionBuffers)
{
    // Calculate the distance to the player before the action
    float distanceToPlayerBefore = Vector3.Distance(this.transform.position, playerTransform.position);

    // Determine the movement vector
    Vector2 move = new Vector2(actionBuffers.ContinuousActions[0], actionBuffers.ContinuousActions[1]);

    // Perform the move action
    rb.MovePosition(rb.position + move * Time.fixedDeltaTime);

    // Calculate the distance to the player after the action
    float distanceToPlayerAfter = Vector3.Distance(this.transform.position, playerTransform.position);

    // Calculate the reward based on whether the NPC got closer or farther from the player
    if (distanceToPlayerAfter < distanceToPlayerBefore)
    {
        // NPC got closer to the player, reward it
        AddReward(0.1f);
    }
    else
    {
        // NPC got farther from the player, punish it
        AddReward(-0.1f);
    }

    // Check if NPC caught the player, end the episode if so
    if (distanceToPlayerAfter < 0.5f)  // 0.5 is a placeholder, replace it with appropriate value
    {
        AddReward(1.0f);  // Give a big reward
        EndEpisode();  // End the current episode
    }
}


    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // This can be used for testing
        // You can manually set the actions based on input
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
