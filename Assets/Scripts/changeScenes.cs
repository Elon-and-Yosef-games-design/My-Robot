using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{
    EnterComputer e;
    [SerializeField] GameObject pc_screen;

    private void Start()
    {

        e = new EnterComputer();

    }
    public void TurnoffPc()
    {
        pc_screen.SetActive(false);
        e.DestroySceneAndEnableScript();
        //_ = SceneManager.UnloadScene("pc");
    }
   
}
