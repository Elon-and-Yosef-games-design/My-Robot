using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{
    EnterComputer e;

    private void Start()
    {

        e = new EnterComputer();

    }
    public void TurnoffPc()
    {
        e.DestroySceneAndEnableScript();
        //_ = SceneManager.UnloadScene("pc");
    }
   
}
