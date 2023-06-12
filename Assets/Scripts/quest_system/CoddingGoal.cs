using PythonSharp.Commands;
using PythonSharp.Compiler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Users;

public class CoddingGoal : questGoal
{
    public string script { get; set; } //item that requierd to get as goal.
    PythonSharp.Machine machine = new PythonSharp.Machine();
    StringWriter stringWriter = new StringWriter();
    string[] test_inputs;
    string[] test_outputs;
    string dialog_text_description;
    //public UnityEvent<GameObject> OnScriptPassedTest;
    public event EventHandler dialogue_m;
    public class event_args : EventArgs { public Dialogue d; }

    public CoddingGoal(Quest quest, string descritption, bool completed, int currentAmount, string[] test_inputs, string[] test_outputs)
    {
        this.description = descritption;
        this.completed = completed;
        this.currentAmout = currentAmount;
        this.test_inputs = test_inputs;
        this.test_outputs = test_outputs;
        this.quest = quest;
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
        Dialogue dialogue = new Dialogue();
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
                dialogue.name = "Codding Error";
                dialogue.sentences = new string [] { "test was failed.", "i was spuose to get: " + output + ".","but for some reson i get:" + stringWriter.ToString() };
                //this.quest.dialogue_manager.StartDialogue(dialogue);
                DialogueManager.Instance.StartDialogue(dialogue);
                Debug.LogAssertion("test was failed." + " i was spuose to get: " + output+". \n but for some reson i get:"+ stringWriter.ToString());
                return;
            }
        }
        this.currentAmout++;
        Evaluate();
    }
}
