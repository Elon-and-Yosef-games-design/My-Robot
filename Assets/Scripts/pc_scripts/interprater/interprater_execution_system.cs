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

    PythonSharp.Machine machine = new PythonSharp.Machine();
    StringWriter stringWriter = new StringWriter();

    string input_str ="";

    private void Start()
    {
        machine.Output = stringWriter;
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
         
       // return hasfiles;
    }



}
