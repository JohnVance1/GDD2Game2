using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    // Following this guide:
    // https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/

    public RigidbodyFirstPersonController controller;

    public bool GetPauseEnabled()
    {
        return this.GetComponentInChildren<Canvas>().enabled;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        this.GetComponentInChildren<Canvas>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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

    /// <summary>
    /// Toggles the pause menu with either the 'Escape' key or 'Resume' button.
    /// </summary>
    public void TogglePauseMenu()
    {
        Debug.Log("toggled pause");
        if(this.GetComponentInChildren<Canvas>().enabled)
        {
            this.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            this.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        Debug.Log("Cursor: " + Cursor.lockState + ", Visible: " + Cursor.visible);
    }
}
