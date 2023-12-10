using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    //main menu UI
    public void OnButtonPress(string buttonValue)
    {
        switch (buttonValue)
        {
            case "Play Level 1":
                {
                    SceneManager.LoadScene("Neighbourhood");
                    break;
                }
            case "Play Level 2":
                {
                    SceneManager.LoadScene("Desert");
                    break;
                }
            case "Quit Game":
                {
                    Application.Quit();
                    break;
                }
            default:
                {
                    break;
                }
        }

    }

}
