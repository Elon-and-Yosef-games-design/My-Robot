using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class pyb_guide : MonoBehaviour
{
    GameObject guide_list_view;
    [SerializeField] GameObject contant;
    [SerializeField] Button button;
    [SerializeField]
    QuestGiver questgiver;
    // Start is called before the first frame update
    void Start()
    {
       /* guide_list_view = this.transform.Find("Scroll View/Viewport/Content").gameObject;
        Debug.Log("pyb guid" +  guide_list_view.name);
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(()=>Debug.Log("clicked"));
        TMP_Text tex = button.GetComponent<TMP_Text>();
        tex.text = "hello";
        Instantiate(button, guide_list_view.transform);*/

    }




    public void clicked_item(GameObject g)
    {
        Debug.Log(g.name);
        GameObject prefab = Resources.Load("programing guide/" + g.name) as GameObject;

        if (prefab != null)
        {
            GameObject child = Instantiate(prefab,contant.transform);
            RectTransform childRect = child.GetComponent<RectTransform>();
            // קבלת הRectTransform של האב
            RectTransform parentRect = contant.GetComponent<RectTransform>();
            // חישוב הPosition של הprefab במרחב המקומי של האב
            Vector2 childPos = new Vector2(parentRect.position.x - parentRect.rect.width / 2f, parentRect.position.y - parentRect.rect.height / 2f);
            // המרת הPosition של הprefab ממרחב המקומי למרחב העולם
            Vector3 worldPos = parentRect.TransformPoint(childPos);
            // שינוי הPosition של הprefab לPosition שחישבנו
            childRect.position = worldPos;
        

        }
        else
        {
            // הדפסת שגיאה אם הprefab לא נמצא
            Debug.LogError("Prefab " + g.name + " not found in Resources folder");
        }
        try
        {
            if (questgiver.current_quest.goals[0].GetType().ToString().Equals("ArrivaleGoal"))
            {
                ((ArrivaleGoal)questgiver.current_quest.goals[0]).arrived(g.name);
            }
        }
        catch { }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
