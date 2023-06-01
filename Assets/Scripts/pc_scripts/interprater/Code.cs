using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Script", menuName = "ScriptableObjects/New_script", order = 1)]
public class Code 
{
    [SerializeField] string script_name = "";
    [SerializeField][TextArea(15, 20)] string code;

    public void write_code(string s, string name)
    {
        code = s;
        script_name = name;
    }
    public string get_name()
    {
        return script_name;
    }
    public string get_code()
    {
        return code;
    }

}
