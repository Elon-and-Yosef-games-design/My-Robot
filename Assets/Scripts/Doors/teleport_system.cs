using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// to use this teleport system call the function spawn and give it the name of the location
/// </summary>
public class teleport_system : MonoBehaviour
{
    [SerializeField] GameObject player;

   public void spawn(string spawn_location)
    {
        GameObject spawn_point = GameObject.Find("Spawn_points").transform.Find(spawn_location).gameObject;

        player.transform.position = spawn_point.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
