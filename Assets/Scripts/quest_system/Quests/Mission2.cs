using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mission2 : Quest
{
    GameObject robot = null;
    void Start()
    {
    
        title = "Hello World";
        description = "It's unbelievable that I found this robot. It's exciting, scary and interesting at the same time.\nLet's see what I can do with it.";
        expReward = 10;

        //here we configure the mini quest for the general quest.
        
        goals.Add(new ArrivaleGoal(this, "Enter the PyB Guide in the computer and check the information about print function.\n to open the computer, press E.", 
            "befor i start anything i should make sure i remmember how to code.\n" +
            "I got from the goverment a guide for the same languge the robot works with", "print function", false, 0));
        goals.Add(new CoddingGoal(this, "open the PyB compiler in the computer and write a program that print to the screen \"hello world\"\nand run it with the RUN button.",
                                        false, 0,new string[] {},new string[] {"hello world\r\n"}));

        goals.Add(new ArrivaleGoal(this, "upload the script to the robot with the UPLOAD button in the IDE.",
            "befor i start anything i should make sure i remmember how to code.\n" +
            "I got from the goverment a guide for the same languge the robot works with", "uploaded", false, 1));

        goals.Add(new CoddingGoal(this,"go to the robot and press E to activate the script you upload",false, 1,new string[] { }, new string[] {"hello world\r\n"}));
        /*goals.Add(new ArrivaleGoal(this, "Go back home, i should be carfull with what i found", "home", false, 1));*/

        //run the initlize for each of the quests
        goals.ForEach(g => g.Init());
    }

    private void Update()
    {
        //Debug.Log("counts = " + goals.Count);
       if (robot != null)
        {
            robot = GameObject.Find("Robot");
        }
       /*else
            if (robot.active ==  false)
            {
            
                robot.SetActive(true);
            }*/
    }
}
