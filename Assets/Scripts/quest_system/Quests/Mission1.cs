using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// In this mission the player will go from his home to the 
/// junk yard to search for the robot and and get back home
/// 
/// </summary>
public class Mission1 : Quest
{
    [SerializeField] GameObject g;
    void Start()
    {
        title = "Scrap Hunter";
        description = "As usual you like to go to the junkyard and search for Scraps.\nWho knows what you may find.";
        expReward = 10;
        coinReward = 5;

        //here we configure the mini quest for the general quest.
        goals.Add(new ArrivaleGoal(this, "Get out of the building and go to the street.\npress E to interact with doors.", "hallway_street_door_2", false, 1));
        goals.Add(new ArrivaleGoal(this, "Turn right and go to the Junk Yard", "junkyard_city_1", false, 1));
        goals.Add(new ArrivaleGoal(this, "Search for goods in the piles, who knows what you will find.\npress E to intercat with the junk piles.", "pile_with_robot", false, 1));
        goals.Add(new ArrivaleGoal(this, "Go back home, i should be carfull with what i found", "home", false, 1));

        //run the initlize for each of the quests
        goals.ForEach(g => g.Init());
    }
    private void Update()
    {
        if(goals.Count < 4) 
        {
            //Debug.Log("in the iif");

        }
    }
}
