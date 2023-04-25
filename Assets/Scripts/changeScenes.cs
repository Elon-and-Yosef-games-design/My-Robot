using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenes : MonoBehaviour
{

    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene("Section2");
    }
}
