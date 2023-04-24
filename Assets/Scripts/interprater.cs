using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class interprater : MonoBehaviour
{
    [SerializeField] TMP_InputField stdout;
    [SerializeField] float print_animation_duration = 2f;


    string input_str; //string i get from the editor willing to split
    Dictionary<string, int> int_varibles = new Dictionary<string, int>();
    Dictionary<string, string> string_varibles = new Dictionary<string, string>();
    Dictionary<string, float> float_varibles = new Dictionary<string, float>();
    Dictionary<string, bool> bool_varibles = new Dictionary<string, bool>();

    string[] reserved_words = { "if", "else", "print" };

    public void read_input_editor(string s)
    {
        input_str = s;
    }
    public void compile()
    {
        StartCoroutine(run_animation());
       
    }
    IEnumerator run_animation()
    {
        stdout.text = ">> python p1.py\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text += ">> ....\n";
        yield return new WaitForSeconds(print_animation_duration);
        stdout.text = ">>";
        cmd(input_str);
    }

    void cmd(string str)
    {
        char[] separators = { '\n'};
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
            Debug.Log(word);
        }
    }

    void varible_assign(string str)
    {
        string[] parts = str.Split('=');
        string type = parts[0].Split(" ")[0];
        string Value = parts[1].Trim();
        string  varName = parts[0].Split(" ")[1];
        switch (type)
        {
            case "int":
                int_varibles.Add(varName, int.Parse(Value));
                break;
            case "float":
                break;
            case "string":
                break;
            case "bool":
                break;
        }
        //varibles.Add(varName, varValue);
    }


    void print_func(string s)
    {
        string[] parts = s.Split(',');
        string output = "";

        foreach (string part in parts)
        {
            int startIndex = part.IndexOf("\"") ; // Find the index of the first opening parenthesis
            if (startIndex >= 0) 
            { 
                int endIndex = part.LastIndexOf("\"")+1; // Find the index of the last closing parenthesis
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

        stdout.text += "" + output + "\n>>";
        Debug.Log(output);
    }

    /* void print_func(string s)
     {
         string myString = s; // Input string
         int startIndex = myString.IndexOf("\"") + 1; // Find the index of the first double quote
         int endIndex = myString.LastIndexOf("\""); // Find the index of the last double quote
         string output = myString.Substring(startIndex, endIndex - startIndex); // Extract the substring

         // Find and replace variable placeholders
         foreach (var kvp in int_varibles)
         {
             string varName = kvp.Key;
             object varValue = kvp.Value;
             output = output.Replace(varName, varValue.ToString());
         }

         stdout.text += ">> " + output + "\n";
         Debug.Log(output);
     }*/
    /*
    void print_func(string s)
    {
        string myString = s; // Input string
        int startIndex = myString.IndexOf("\"") + 1; // Find the index of the first double quote
        int endIndex = myString.LastIndexOf("\""); // Find the index of the last double quote
        string output = myString.Substring(startIndex, endIndex - startIndex); // Extract the substring
        stdout.text += ">> " + output+"\n";
        Debug.LogAssertion(output);
    }*/

}
