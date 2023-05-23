using PythonSharp.Commands;
using PythonSharp.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.Users;

public class CoddingGoal : questGoal
{
    public string script { get; set; } //item that requierd to get as goal.
    PythonSharp.Machine machine = new PythonSharp.Machine();
    StringWriter stringWriter = new StringWriter();
    string[] test_inputs;
    string[] test_outputs;
    string dialog_text_description;

    public CoddingGoal(Quest quest, string descritption, bool completed, int currentAmount, string[] test_inputs, string[] test_outputs)
    {
        this.description = descritption;
        this.completed = completed;
        this.currentAmout = currentAmount;
        this.test_inputs = test_inputs;
        this.test_outputs = test_outputs;
    }
    public CoddingGoal(Quest quest, string descritption, string dialog_text, bool completed, int currentAmount, string[] test_inputs, string[] test_outputs)
    {
        this.description = descritption;
        this.completed = completed;
        this.currentAmout = currentAmount;
        this.test_inputs = test_inputs;
        this.test_outputs = test_outputs;
        this.dialog_text_description = dialog_text;
    }
    public override void Init()
    {
        base.Init();
        machine.Output = stringWriter;
    }

    public void scriptPassedTest(string code_to_test)
    {
        stringWriter.GetStringBuilder().Clear();
        foreach (string output in test_outputs)
        {
            Parser parser = new Parser(code_to_test);
            ICommand command = parser.CompileCommandList();
            command.Execute(machine.Environment);
            
            if (output.Equals(stringWriter.ToString()))
            {
                continue;
            }
            else
            {
                Debug.LogAssertion("test was failed." + " i was spuose to get: " + output+". \n but for some reson i get:"+ stringWriter.ToString());
                return;
            }
        }
        this.currentAmout++;
        Evaluate();
    }
}
