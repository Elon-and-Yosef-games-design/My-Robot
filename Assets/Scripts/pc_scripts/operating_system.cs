using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operating_system : MonoBehaviour
{

    [SerializeField] GameObject IDE_program;
    [SerializeField] GameObject Dark_Web;
    [SerializeField] GameObject pyb_guide;
    // Start is called before the first frame update
    void Start()
    {
        IDE_program.active = false;
        Dark_Web.active = false;
    }

    public void on_off_IDE()
    {
        IDE_program.active = !IDE_program.active;
    }
    public void on_off_pyb_guide()
    {
        pyb_guide.active = !pyb_guide.active;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
