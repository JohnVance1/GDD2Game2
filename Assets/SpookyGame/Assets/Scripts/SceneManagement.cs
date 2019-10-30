using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManagement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    string button;
    // Start is called before the first frame update
    void Start()
    {
        button = "";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(button);
        if(Input.GetMouseButtonDown(0))
        {
            if(button == "PlayButton")
            {
                SceneManager.LoadScene(2);
            }
            else if (button == "MenuButton")
            {
                SceneManager.LoadScene(0);
            }
            else if (button == "CreditsButton")
            {
                SceneManager.LoadScene(1);
            }
            else if (button == "QuitButton")
            {
                Application.Quit();
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        button = name;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        button = "";
    }
}
