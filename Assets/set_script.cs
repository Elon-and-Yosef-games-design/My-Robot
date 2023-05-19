using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class set_script : MonoBehaviour
{
    [SerializeField]
    QuestGiver questgiver;

    [SerializeField]
    interprater_execution_system code_input_filed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// this function for now will handle the quest test sending
    /// </summary>
   public void upload_code()
    {
        if (questgiver.current_quest.goals[0].GetType().ToString().Equals("CoddingGoal"))
        {
                ((CoddingGoal)questgiver.current_quest.goals[0]).scriptPassedTest(code_input_filed.get_current_code());
        }
    }
}
