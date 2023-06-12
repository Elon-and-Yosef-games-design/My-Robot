using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTracker : MonoBehaviour
{
    public static bool hasVisitedGarbage = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

