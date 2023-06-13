using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.IO;
using PythonSharp.Compiler;
using PythonSharp.Commands;


public class Robot_interprater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stdout;
    [SerializeField] float print_animation_duration = 2f;
    [SerializeField] Code script = null;

    QuestGiver questgiver;
    private PythonSharp.Machine mach;
    StringWriter stringWriter;

    string input_str="";
    private void Start()
    {
        mach = new PythonSharp.Machine();
        stringWriter = new StringWriter();
        mach.Output = stringWriter;
        questgiver = GameObject.Find("Quest_giver").GetComponent<QuestGiver>();
        Debug.Log("Robot start!!!!");
    }

    public void upload_to_robot(string str)
    {
        script = new Code();
        script.write_code(str,"p1");
    }

    public void Load_script()
    {
        input_str = script.get_code();
    }
    public void compile()
    {

        StartCoroutine(run_animation());

    }
    IEnumerator run_animation()
    {
        
        stdout.text = "$ python "+script.get_name() + ".pyb\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text += "$ ....\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text = " ";
        cmd(script.get_code());
    }

    void cmd(string str)
    {
        Parser parser = new Parser(str);
        ICommand command = parser.CompileCommandList();
        command.Execute(mach.Environment);
        stdout.text = stringWriter.ToString();
        if (questgiver.current_quest.goals[0].GetType().ToString().Equals("CoddingGoal"))
        {
            ((CoddingGoal)questgiver.current_quest.goals[0]).scriptPassedTest(input_str);
        }
    }

    


   


}
