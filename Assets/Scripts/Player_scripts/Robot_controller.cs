using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robot_controller : MonoBehaviour
{

    [SerializeField] GameObject robot;
    public static Robot_controller instance;

    public void turn_robot_on()
    {
        robot.SetActive(true);
    }
    private void Awake()
    {
        instance = this;    
    }
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Door1>())
        {
            sceneToLoad = "hollway";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door2>())
        {
            sceneToLoad = "room";
            enterAllowed = true;
        }
        else if (collision.GetComponent<Door3>())
        {
            sceneToLoad = "dump";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Door1>() || collision.GetComponent<Door2>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
