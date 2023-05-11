using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class controller_e : MonoBehaviour
{
    [SerializeField]
    float multiplier = 1f;//multiplier of run speed

    [SerializeField]
    float speed = 1.0f;// step sizes

    [SerializeField]
    InputAction moveUp = new InputAction();
    [SerializeField]
    InputAction moveDown = new InputAction();
    [SerializeField]
    InputAction moveLeft = new InputAction();
    [SerializeField]
    InputAction moveRight = new InputAction();

    [SerializeField]
    InputAction Vertical_key = new InputAction();

    [SerializeField]
    InputAction run = new InputAction();

    [SerializeField]
    InputAction open_quest = new InputAction();

    [SerializeField]
    QuestGiver questgiver;

    [SerializeField]
    InputAction Action = new InputAction();

    [SerializeField]Animator animator;


    int run_flag = 0;
    float multiplier_run;
    Collider2D current_collision = null;
    float Vertical = 0f;
    float Horizontal = 0f;


    private void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();
        run.Enable();
        open_quest.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter collision");
        current_collision = collision;
        try
        {
            if (questgiver.current_quest.goals[0].GetType().ToString().Equals("ArrivaleGoal"))
            {
                Debug.Log("type of goal: " + questgiver.current_quest.goals[0].GetType());
                ((ArrivaleGoal)questgiver.current_quest.goals[0]).arrived(collision.name);
            }
            if (questgiver.current_quest.goals[0].GetType().ToString().Equals("ArrivaleGoal"))
            {
                Debug.Log("press E to interact!\n");
                Debug.Log("type of goal: " + questgiver.current_quest.goals[0].GetType());
          
            }
        }
        catch
        {
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        current_collision = null;
    }

    private void Start()
    {
        multiplier_run = 1;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        if (run.IsPressed() && run_flag == 0)
        {

            multiplier_run = multiplier;
            run_flag = 1;
        }
        else
        {
            multiplier_run = 1;
            run_flag = 0;
        }

         Vertical = Input.GetAxisRaw("Vertical") * speed;
        animator.SetFloat("vertical_speed", Vertical);

        Horizontal = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("horizontal_speed", Horizontal);

        //transform.position.
        //transform.position.Scale(new Vector3(Vertical,0));

        if (moveUp.IsPressed())
        {
            transform.position += new Vector3(0, multiplier_run * speed * Time.deltaTime, 0);

        }
        if (moveDown.IsPressed())
        {
            transform.position += new Vector3(0, -1 * multiplier_run * speed * Time.deltaTime, 0);
            Debug.Log("Vertical" + Vertical);
           
        }
        if (moveLeft.IsPressed())
            transform.position += new Vector3(-1 * multiplier_run * speed * Time.deltaTime, 0, 0);
        if (moveRight.IsPressed())
            transform.position += new Vector3(multiplier_run * speed * Time.deltaTime, 0, 0);
        if (open_quest.WasPressedThisFrame())
        {
            if(questgiver.isOpen())
            {
                questgiver.close_window();
            }
            else
            {
                questgiver.open_window();
            }
        }
        if (Action.IsPressed())
        {
            Debug.Log("E was pressed!\n");
            try
            {
                if (questgiver.current_quest.goals[0].GetType().ToString().Equals("ArrivaleGoal"))
                {
                    if (current_collision != null)
                        ((ArrivaleGoal)questgiver.current_quest.goals[0]).arrived(current_collision.name);
                }
            }
            catch
            {
                Debug.Log("dosent have quest");
            }   
        }
        else
        {
        }
    }
}
