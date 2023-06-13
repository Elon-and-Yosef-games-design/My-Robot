using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PythonSharp;
using PythonSharp.Commands;
using PythonSharp.Compiler;
using PythonSharp.Expressions;
using PythonSharp.Utilities;
using UnityEngine.InputSystem.Users;
using Unity.VisualScripting;

public class interprater_execution_system : MonoBehaviour
{
    [SerializeField] TMP_InputField stdout;
    [SerializeField] TMP_InputField stdin ;
    [SerializeField] float print_animation_duration = 0.5f;
    QuestGiver questgiver;


    PythonSharp.Machine machine = new PythonSharp.Machine();
    StringWriter stringWriter = new StringWriter();

    string input_str ="";

    private void Start()
    {
        machine.Output = stringWriter;
        questgiver = GameObject.Find("Quest_giver").GetComponent<QuestGiver>();
    }


    public void compile()
    {

        StartCoroutine(run_animation());

    }
    IEnumerator run_animation()
    {
        stringWriter.GetStringBuilder().Clear();
        stdout.text = ">> pybot p1.py\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text += ">> ....\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text = ">>";
        ProcessFiles();
    }
    IEnumerator upload_animation()
    {
        stringWriter.GetStringBuilder().Clear();
        stdout.text = ">> uploading p1.py\n";
        yield return new WaitForSeconds(print_animation_duration);
        GameObject.Find("Robot").GetComponent<Robot_interprater>().upload_to_robot(input_str);
        stdout.text += ">> ....\n";
        stdout.text += ">> upload finished\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text = ">>";
        if (questgiver.current_quest.goals[0].GetType().ToString().Equals("ArrivaleGoal"))
        {
            ((ArrivaleGoal)questgiver.current_quest.goals[0]).arrived("uploaded");
        }

    }
    public void upload_code()
    {
        StartCoroutine(upload_animation());
    }

    public void read_input_editor(string s)
    {
        input_str = s;
    }
    public string get_current_code()
    {
        return input_str;
    }
    public void ProcessFiles()
    {

        Parser parser = new Parser(input_str);
        ICommand command = parser.CompileCommandList();
        command.Execute(machine.Environment);
        stdout.text = stringWriter.ToString();
        if(questgiver.current_quest.goals[0].GetType().ToString().Equals("CoddingGoal"))
        {
            ((CoddingGoal)questgiver.current_quest.goals[0]).scriptPassedTest(input_str);
        }
         
       // return hasfiles;
    }



}
