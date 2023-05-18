using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

/// <summary>
/// this is the system that give the quest for the player
/// </summary>
public class QuestGiver : MonoBehaviour
{
    [SerializeField]
    public List<string> quests = new List<string>();
    int i = 0;

    
    [SerializeField]
    public Player player = null;

    [Tooltip("set the quest object that in the player")]
    public GameObject quest_object;

    [SerializeField]
    public GameObject questWindow;

     TextMeshProUGUI title_text;
     TextMeshProUGUI discription_text;
     TextMeshProUGUI Goal_discrip_text;
     TextMeshProUGUI coin_text;
     GameObject coin_icon;    

    [Tooltip("no need to assigned")]
    public Quest current_quest;


    private void Start()
    {
        quest_object = player.transform.Find("quest").gameObject;
        title_text = questWindow.transform.Find("Quest_Title").GetComponent<TextMeshProUGUI>();
        discription_text = questWindow.transform.Find("Quest_Description").GetComponent<TextMeshProUGUI>();
        Goal_discrip_text = questWindow.transform.Find("Task_box").transform.Find("Goal discription").GetComponent<TextMeshProUGUI>();
        coin_text = questWindow.transform.Find("coin box").transform.Find("coin").GetComponent<TextMeshProUGUI>();
        coin_icon = questWindow.transform.Find("coin box").gameObject;
        AssigneQuest();
    }
    private void Update()
    {
        nextQuest();
    }

    public void nextQuest()
    {
        if(current_quest.goals.Count > 0)
            if (current_quest.goals[0].completed)
            {
                Debug.Log("goal completed");
                //StartCoroutine(new_misson());
                
                if (current_quest.Completed)
                {
                    current_quest.GiveRewarde();

                    if (quests.Count > i + 1)
                    {
                        Destroy(quest_object.GetComponent(System.Type.GetType(quests[i])));
                        i++;
                        AssigneQuest();
                    }
                   
                    //current_quest = 
                }
                else
                    current_quest.goals.RemoveAt(0);
               
                StartCoroutine(new_misson());
            }
    }
    
    void AssigneQuest()
    {
        /*try
        {
            if (quest_object.GetComponent<Quest>().name.Equals(quests[i]))
            {
                Debug.Log("assigned quest " + quests[i]);
            }
        }
        catch
        {

        }*/
  
        current_quest = (Quest)quest_object.AddComponent(System.Type.GetType(quests[i]));//this will assigned the quest from the list to the quest object
    }

    IEnumerator new_misson()
    {
        open_window();
        yield return new WaitForSeconds(3);
        close_window();
    }

    public bool isOpen()
    {
        return questWindow.active;
    }
    public void open_window()
    {
        try
        {
            Debug.Log("current_quest.goals[0].description: " + current_quest.goals[0].description);
            questWindow.SetActive(true);
            title_text.text = current_quest.title;
            discription_text.text = current_quest.description;
            Goal_discrip_text.text = current_quest.goals[0].description;
            if (current_quest.coinReward > 0)
            {
                coin_text.text = current_quest.coinReward.ToString();
                coin_icon.SetActive(true);
            }
            else { coin_icon.SetActive(false); }
        }
        catch
        {
            questWindow.SetActive(true);
            title_text.text = "No mission Avilible";
            discription_text.text = "";
            Goal_discrip_text.text = "";
            coin_icon.SetActive(false);
        }
        
    }
    public void close_window()
    {
        questWindow.SetActive(false);
    }


}
