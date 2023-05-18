using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject instructionsPanel; // assign in inspector

    // Use this for initialization
    void Start()
    {
        instructionsPanel.SetActive(false); // hide at start
    }

    public void ToggleInstructions()
    {
        // If panel is active, hide it, else show it
        instructionsPanel.SetActive(!instructionsPanel.activeSelf);
    }
}
