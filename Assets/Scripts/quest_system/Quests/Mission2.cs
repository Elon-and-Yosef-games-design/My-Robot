using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2 : Quest
{
    void Start()
    {
        title = "Hello World";
        description = "It's unbelievable that I found this robot. It's exciting, scary and interesting at the same time.\nLet's see what I can do with it.";
        expReward = 10;

        //here we configure the mini quest for the general quest.
        
        goals.Add(new ArrivaleGoal(this, "Enter the print Guide in the computer", 
            "befor i start anything i should make sure i remmember how to code.\n" +
            "I got from the goverment a guide for the same languge the robot works with", "print function", false, 0));
        goals.Add(new CoddingGoal(this, "write a program that print to the screen \"hello world\" \nand run it with the run button.",
                                        false, 0,new string[] {},new string[] {"hello world\r\n"}));

        goals.Add(new ArrivaleGoal(this, "upload the script to the robot with the upload button in the IDE.",
            "befor i start anything i should make sure i remmember how to code.\n" +
            "I got from the goverment a guide for the same languge the robot works with", "uploaded", false, 1));

        goals.Add(new CoddingGoal(this,"go to the robot and press E to activate the script you upload",false, 1,new string[] { }, new string[] {"hello world\r\n"}));
        /*goals.Add(new ArrivaleGoal(this, "Go back home, i should be carfull with what i found", "home", false, 1));*/

        //run the initlize for each of the quests
        goals.ForEach(g => g.Init());

    }
}
