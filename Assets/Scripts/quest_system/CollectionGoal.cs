using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal: questGoal
{
    public string itemID { get; set; } //item that requierd to get as goal.

    public CollectionGoal(Quest quest, string itemID, bool completed, int currentAmount)
    {
        this.itemID = itemID;
        this.completed = completed;
        this.currentAmout = currentAmount;
    }
    public override void Init()
    {
        base.Init();
    }

    void ItemPicked()
    {

    }
}
