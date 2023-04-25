using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class controller_e : MonoBehaviour
{
    [SerializeField]
    float multiplier = 1f;//multiplier of run speed

    [SerializeField]
    float speed = 1.0f;// step sizes

    [SerializeField]
    InputAction moveUp = new InputAction();

    [SerializeField]
    InputAction moveDown = new InputAction();

    [SerializeField]
    InputAction moveLeft = new InputAction();

    [SerializeField]
    InputAction moveRight = new InputAction();


    [SerializeField]
    InputAction run = new InputAction();

    int run_flag = 0;
    float multiplier_run;


    private void OnEnable()
    {
        moveUp.Enable();
        moveDown.Enable();
        moveLeft.Enable();
        moveRight.Enable();
        run.Enable();
    }

    private void Start()
    {
        multiplier_run = 1;
    }


    // Update is called once per frame
    void Update()
    {
        if (run.IsPressed() && run_flag == 0)
        {
            multiplier_run = multiplier;
            run_flag = 1;
        }
        else
        {
            multiplier_run = 1;
            run_flag = 0;
        }
        if (moveUp.IsPressed())
            transform.position += new Vector3(0, multiplier_run * speed * Time.deltaTime, 0);
        if (moveDown.IsPressed())
            transform.position += new Vector3(0, -1 * multiplier_run * speed * Time.deltaTime, 0);
        if (moveLeft.IsPressed())
            transform.position += new Vector3(-1 * multiplier_run * speed * Time.deltaTime, 0, 0);
        if (moveRight.IsPressed())
            transform.position += new Vector3(multiplier_run * speed * Time.deltaTime, 0, 0);
    }
}
