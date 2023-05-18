using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnterComputer : MonoBehaviour
{
    private bool enterAllowed;
    private string previousScene;
    static bool inpc = false;
    [SerializeField] public string sceneToLoad = "Pc";
    [SerializeField] InputAction Action = new InputAction();

    [SerializeField] GameObject pc_screen;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.tag == "PC")
        {
            enterAllowed = true;

            Debug.Log("enterAllowed  "+ enterAllowed);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "PC")
        {
            enterAllowed = false;

            Debug.Log("Player is no longer touching the computer.");
        }


    }

    private void OnEnable()
    {
        Action.Enable();
     
    }
    private void Update()
    {
        if (enterAllowed  && !inpc && Action.IsPressed() )
        {
            Debug.Log("start...");
            inpc = true;
            GetComponent<controller_e>().enabled = false;
            pc_screen.SetActive(true);
            //previousScene = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        }
        if(!inpc)
        {
            if (GetComponent<controller_e>().enabled == false)
                GetComponent<controller_e>().enabled = true;
        }

    }

    /// <summary>
    /// this function helps to load and unload the pc include flagging when we out of the pc 
    /// so we can enable controller
    /// </summary>
    public void DestroySceneAndEnableScript()
    {

        inpc = false;
        try
        {
            pc_screen.SetActive(false);
        }
        catch
        {

        }
        //SceneManager.UnloadSceneAsync(sceneToLoad);        
    }


    }

