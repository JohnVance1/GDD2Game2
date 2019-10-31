using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManagement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject menuAudio;
    string button;
    // Start is called before the first frame update
    void Start()
    {
        menuAudio = GameObject.FindGameObjectWithTag("MenuAudio");
        button = "";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(button);
        if(Input.GetMouseButtonDown(0))
        {
            menuAudio.GetComponent<AudioSource>().volume = 1.0f;

            if (button == "PlayButton")
            {
                menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonSelect");
                menuAudio.GetComponent<AudioSource>().Play();
                //if (Input.GetMouseButtonUp(0))
                    SceneManager.LoadScene(2);
            }
            else if (button == "MenuButton")
            {
                menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonSelect");
                menuAudio.GetComponent<AudioSource>().Play();
                //if (Input.GetMouseButtonUp(0))
                    SceneManager.LoadScene(0);
            }
            else if (button == "CreditsButton")
            {
                menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonSelect");
                menuAudio.GetComponent<AudioSource>().Play();
                //if (Input.GetMouseButtonUp(0))
                    SceneManager.LoadScene(1);
            }
            else if (button == "ResumeButton")
            {
                menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonSelect");
                menuAudio.GetComponent<AudioSource>().Play();
                //if (Input.GetMouseButtonUp(0))
                    GameObject.FindGameObjectWithTag("UI").GetComponent<GameManager>().TogglePauseMenu();
            }
            else if (button == "QuitButton")
            {
                menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonSelect");
                menuAudio.GetComponent<AudioSource>().Play();
                //if (Input.GetMouseButtonUp(0))
                    Application.Quit();
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        button = name;
        menuAudio.GetComponent<AudioSource>().volume = 0.4f;
        menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonHover");
        menuAudio.GetComponent<AudioSource>().Play();
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        button = "";
        menuAudio.GetComponent<AudioSource>().volume = 0.2f;
        menuAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("BonyBoy_ButtonHover");
        menuAudio.GetComponent<AudioSource>().Play();
    }
}
