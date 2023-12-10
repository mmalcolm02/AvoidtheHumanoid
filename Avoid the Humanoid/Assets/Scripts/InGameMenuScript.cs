using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuScript : MonoBehaviour
{
    //script to access in game menu superceeded by game manager and suitable for refactoring
    public GameObject menuCanvas;

    public void OnButtonPress(string buttonText)
    {
        switch (buttonText)
        {
            case "MainMenu":
                {
                    SceneManager.LoadScene("Main Menu");
                    break;
                }

            case "Back":
                {
                    menuCanvas.SetActive(false);
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
            }
    }
}
