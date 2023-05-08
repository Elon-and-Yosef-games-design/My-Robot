using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class Robot_interprater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stdout;
    [SerializeField] float print_animation_duration = 2f;
    [SerializeField] Code script;

    List<Code> Scripts = new List<Code>();


    string input_str; //string i get from the editor willing to split
    Dictionary<string, int> int_varibles = new Dictionary<string, int>();
    Dictionary<string, string> string_varibles = new Dictionary<string, string>();
    Dictionary<string, float> float_varibles = new Dictionary<string, float>();
    Dictionary<string, bool> bool_varibles = new Dictionary<string, bool>();

    List<string> used_module = new List<string>();

    private void Start()
    {
        Load_script();
        compile();
    }

    public void Load_script()
    {
        input_str = script.get_code();
    }
    public void compile()
    {
        int_varibles.Clear();
        string_varibles.Clear();
        float_varibles.Clear();
        bool_varibles.Clear();
        StartCoroutine(run_animation());

    }
    IEnumerator run_animation()
    {
        
        stdout.text = "$ python"+script.name+".pyb\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text += "$ ....\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text = " ";
        cmd(input_str);
    }

    void cmd(string str)
    {
        char[] separators = { '\n' };
        string[] words = str.Split(separators);

        foreach (string word in words)
        {
            if (word.Contains("print("))
            {
                print_func(word);
            }
            else if (word.Contains("="))
            {
                varible_assign(word);
            }
            else if (word.Contains("import"))
            {
                modules_import(word.Split(new char[] { ' ' })[1]);
            }

            ////modules handaling
            ///search for functions of modules

            Debug.Log(word);
        }
    }

    void varible_assign(string str)
    {
        string[] parts = str.Split('=');
        string type = parts[0].Split(" ")[0];
        string Value = parts[1].Trim();
        string varName = parts[0].Split(" ")[1];
        try
        {
            switch (type)
            {
                case "int":
                    int_varibles.Add(varName, int.Parse(Value));
                    break;
                case "float":
                    float_varibles.Add(varName, float.Parse(Value));
                    break;
                case "string":
                    string_varibles.Add(varName, Value);
                    break;
                case "bool":
                    bool_varibles.Add(varName, bool.Parse(Value));
                    break;
            }
        }
        catch (Exception e)
        {
            stdout.text = "wrong type assignment decleration\n>>";
        }
        //varibles.Add(varName, varValue);
    }


    void print_func(string s)
    {
        int startIndex = s.IndexOf("(") + 1;
        int endIndex = s.LastIndexOf(")");
        s = s.Substring(startIndex, endIndex - startIndex);
        string[] parts = s.Split(',');
        string output = "";

        foreach (string part in parts)
        {
            startIndex = part.IndexOf("\""); // Find the index of the first opening parenthesis
            if (startIndex >= 0)
            {
                endIndex = part.LastIndexOf("\"") + 1; // Find the index of the last closing parenthesis
                string temp = part.Substring(startIndex, endIndex - startIndex);
                if (temp.StartsWith("\"") && temp.EndsWith("\""))
                {
                    // This part is a string literal
                    output += temp.Substring(1, temp.Length - 2);
                }
            }
            else
            {
                // This part is a variable
                string varName = Regex.Replace(part, @"[^\w]", "").Trim();//part.Trim();

                if (int_varibles.ContainsKey(varName))
                {
                    output += int_varibles[varName].ToString();
                }
                else if (float_varibles.ContainsKey(varName))
                {
                    output += float_varibles[varName].ToString();
                }
                else if (string_varibles.ContainsKey(varName))
                {
                    output += string_varibles[varName];
                }
                else if (bool_varibles.ContainsKey(varName))
                {
                    output += bool_varibles[varName].ToString();
                }
                else
                {
                    output += "Variable " + varName + " not found";
                }
            }
        }

        stdout.text += "" + output + "\n ";
        Debug.Log(output);
    }


    void modules_import(string modoul_name)
    {
        switch (modoul_name)
        {
            case "Voice_modoule":
                used_module.Add(modoul_name);
                break;
            default:
                stdout.text += "no such module" + modoul_name + "\n ";
                break;
        }
    }

    void module_handling(string modoul_name)
    {
        switch (modoul_name)
        {
            //case 
        }
    }
}
