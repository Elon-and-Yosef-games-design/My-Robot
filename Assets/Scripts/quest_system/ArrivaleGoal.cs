using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivaleGoal : questGoal
{

    public string area { get; set; }
    
    public override void Init()
    {
        base.Init();
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="quest">refference to the major quest</param>
    /// <param name="descritption"></param>
    /// <param name="area"></param>
    /// <param name="completed"></param>
    /// <param name="requierdAmount"></param>
    public ArrivaleGoal(Quest quest,string descritption, string area, bool completed, int requierdAmount)
    {
        this.quest = quest;
        this.description = descritption;
        this.area = area;
        this.completed = completed;
        this.requierdAmount = requierdAmount;
    }

    /// <summary>
    /// this function is update the mission prograss when the player got to the requierd
    /// loaction.
    /// work the best with detect which object plyer collided with and give the name of the object to the 
    /// function
    /// </summary>
    /// <param name="arae">the name of the area to arrive to</param>
    public void arrived(string arae)
    {
        if(arae.Equals(this.area))
        {
            //Debug.Log("good, the area is it " + this.area);
            this.currentAmout++;
            Evaluate();
        }
    }
}
