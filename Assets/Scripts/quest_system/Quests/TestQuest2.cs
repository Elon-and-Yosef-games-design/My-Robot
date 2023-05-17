using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;


public class TestQuest2 : Quest
{
    void Start()
    {
        title = "My first code!";
        description = "Time to messe my hands with some codding\nsolve the following codding problems.";
        expReward = 10;
        coinReward = 5;

        //here we configure the mini quest for the general quest.
        goals.Add(new CoddingGoal(this, "write code that will print the \"hello world!\"", 
                false, 0,new string [] {""},new string [] {"hello world!\r\n"}));
        //run the initlize for each of the quests
        goals.ForEach(g => g.Init());
        
    }
    
}
