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

    PythonSharp.Machine machine = new PythonSharp.Machine();
    StringWriter stringWriter = new StringWriter();

    string input_str ="";
    private void Start()
    {

    }
    public void read_input_editor(string s)
    {
        input_str = s;
    }
    public void ProcessFiles()
    {

        // Create a new StringWriter object
        StringWriter stringWriter = new StringWriter();

        // Set the output property of the machine to the StringWriter
        machine.Output = stringWriter;

        Parser parser = new Parser(input_str);
            ICommand command = parser.CompileCommandList();
            command.Execute(machine.Environment);
            stdout.text = stringWriter.ToString();    
         
       // return hasfiles;
    }



}
