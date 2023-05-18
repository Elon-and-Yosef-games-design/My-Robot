using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this mission the player will go from his home to the 
/// junk yard to search for the robot and and get back home
/// 
/// </summary>
public class Mission1 : Quest
{
    void Start()
    {
        title = "Scrap Hunter";
        description = "As usual you like to go to the junkyard and search for Scraps.\nWho knows what you may find.";
        expReward = 10;
        coinReward = 5;

        //here we configure the mini quest for the general quest.
        goals.Add(new ArrivaleGoal(this, "Go to the street", "main street", false, 1));
        goals.Add(new ArrivaleGoal(this, "Go to the Junk Yard", "junk yard", false, 1));
        goals.Add(new ArrivaleGoal(this, "Search for goods in the piles", "pile 1", false, 1));
        goals.Add(new ArrivaleGoal(this, "Go back home, i should be carfull with what i found", "home", false, 1));

        //run the initlize for each of the quests
        goals.ForEach(g => g.Init());

    }
}
