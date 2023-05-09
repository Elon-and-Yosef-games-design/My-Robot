using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoddingGoal : questGoal
{
    public string script { get; set; } //item that requierd to get as goal.

    public CoddingGoal(Quest quest, string script, bool completed, int currentAmount)
    {
        this.script = script;
        this.completed = completed;
        this.currentAmout = currentAmount;
    }
    public override void Init()
    {
        base.Init();
    }

    void scriptPassedTest()
    {

    }
}
