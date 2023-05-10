using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;


public class TestQuest1 : Quest
{
    void Start()
    {
        title = "Scrap Hunter";
        description = "As usual you like to go to the junkyard and search for Scraps.\nHow knows what you may find.";
        expReward = 10;
        coinReward = 5;

        //here we configure the mini quest for the general quest.
        goals.Add(new ArrivaleGoal(this,"Go to the JunkYard", "JunkYard", false, 1));
        goals.Add(new ArrivaleGoal(this,"Go to the first pile", "pile 1", false, 1));
        //run the initlize for each of the quests
        goals.ForEach(g => g.Init());
    }
}
