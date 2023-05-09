using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivaleGoal : questGoal
{

    public string area { get; set; }

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

    void arraived(string arae)
    {
        if(area == this.area)
        {
            this.currentAmout++;
            Evaluate();
        }
    }
}
