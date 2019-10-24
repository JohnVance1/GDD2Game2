using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Following this guide:
    // https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/

    public GameObject UI;

    public bool GetPauseEnabled()
    {
        return UI.GetComponentInChildren<Canvas>().enabled;
    }

    void Start()
    {
        UI.GetComponentInChildren<Canvas>().enabled = false;
    }

    void Update()
    {
        ScanForPauseInput();
    }

    void ScanForPauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }

    public void TogglePauseMenu()
    {
        if(UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
        }
    }
}
