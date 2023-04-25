using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_icon_blinker : MonoBehaviour
{
    [SerializeField]
    float blinking_speed = 1f;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Blinker());// a function that can run function as a thread
    }
    IEnumerator Blinker()// A method that can be paused and continue later
    {
        while (true)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinking_speed);// pause the function for a while
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinking_speed);
        }
    }
}
