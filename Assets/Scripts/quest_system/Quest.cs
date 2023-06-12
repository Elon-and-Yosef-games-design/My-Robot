using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;// this is query library
using UnityEngine.UI;

/// <summary>
/// this class discribe the attrebiuts of quests
/// this is a main Quest as you can see it contain mini quests.
/// </summary>
[System.Serializable]
public class Quest : MonoBehaviour
{
    bool isActive;
    public string title;
    public string description;
    public int expReward;
    public int coinReward;
    // Todo: add item reaward when inventory system is in
    public List<questGoal> goals { get; set; } =  new List<questGoal>();

    public bool Completed;

    [SerializeField] public DialogueManager dialogue_manager;

    /// <summary>
    /// check if all the Goals were achived
    /// </summary>
    /// <param name="player">the player reference for the reward</param>
    public void CheckGoals()
    {
        Completed = goals.All(g => g.completed);// return true if all the goals are true.
        if (Completed)
            GiveRewarde();
    }

   public void GiveRewarde()
    {
        Player p = gameObject.transform.parent.GetComponent<Player>();
        Debug.Log("giving rewarde!");
        // Todo: add item reward handeling
        if (expReward > 0) 
        {
            p.exp += expReward;
        }
        if (coinReward > 0)
        {
            p.coins += coinReward;
        }
    }


}
