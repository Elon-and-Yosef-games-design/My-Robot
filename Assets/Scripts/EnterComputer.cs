using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterComputer : MonoBehaviour
{
    private bool enterAllowed;
    private string previousScene;
    [SerializeField] public string sceneToLoad;
    [SerializeField] public GameObject computer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player is now touching the computer.");
        //Debug.Log(collision.GameObject.name);
        if (collision.GetComponent<computerObject>())
        {
            sceneToLoad = "Pc";
            enterAllowed = true;
        }
        // else if (collision.GetComponent<BrownDoor>())
        // {
        //     sceneToLoad = "Section2";
        //     enterAllowed = true;
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Player is no longer touching the computer.");
        // if (collision.GetComponent<computerObject>() )//|| collision.GetComponent<BrownDoor>())
        // {
        //     enterAllowed = false;
        // }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            previousScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneToLoad);
        }

        // if (Input.GetKeyDown(KeyCode.Q))
        // {
        //     if (!string.IsNullOrEmpty(previousScene))
        //     {
        //         SceneManager.LoadScene(previousScene);
        //     }
        //     else
        //     {
        //         Debug.LogWarning("No previous scene found to return to.");
        //     }
        // }
    }

    private void OnCollisonEnter2D(Collision2D collision){
        //Debug.Log("Player is now touching the computer.");
    }
}

