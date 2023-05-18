using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

/// <summary>
/// this is the system that give the quest for the player
/// </summary>
[System.Serializable]
public class QuestGiver : MonoBehaviour
{
    public List<string> quests = new List<string>();
    int i = 0;
    [Tooltip("set the quest object that in the player")]
    public GameObject quest_object;
    public Player player;
    public GameObject questWindow;
    public TextMeshProUGUI title_text;
    public TextMeshProUGUI discription_text;
    public TextMeshProUGUI Goal_discrip_text;
    public TextMeshProUGUI coin_text;
    public GameObject coin_icon;    
    [Tooltip("no need to assigned")]
    public Quest current_quest;

    
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

    private void Start()
    {
       AssigneQuest();
    }
    private void Update()
    {
        nextQuest();
    }
}
