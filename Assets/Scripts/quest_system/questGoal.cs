using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class questGoal
{
    //public GoalType type;
    public Quest quest { set; get; }
    public int requierdAmount;
    public int currentAmout = 0;
    public bool completed { get; set; }
    public string description;

    public virtual void Init()
    {
        //deafual initialize
    }

    public void Evaluate()
    {
        if(currentAmout >= requierdAmount)
        {   
            complete();
        }
    }

    /// <summary>
    /// make the mission complete
    /// </summary>
    public void complete()
    {
        
        completed = true;
        quest.CheckGoals();
    }

}
