using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceen_controller : MonoBehaviour
{

    public void Main_world()
    {
        SceneManager.LoadScene("Main_world");
    }
    public void Section3()
    {
        SceneManager.LoadScene("Section3");
    }
    public void home()
    {
        SceneManager.LoadScene("main menu");
    }
}