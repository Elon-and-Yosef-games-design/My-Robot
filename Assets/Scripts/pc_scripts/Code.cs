using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Script", menuName = "ScriptableObjects/New_script", order = 1)]
public class Code : ScriptableObject
{
    [SerializeField]string code;

    public void write_code(string s)
    {
        code = s;
    }
    public string get_code()
    {
        return code;
    }

}
