using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private DotProductScript dotProductScript;
    public Timer timer;
    public GameObject gameOverCanvas;
    public GameObject buttonHolderCanvas;
    public GameObject timeUpCanvas;
    public bool gameOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        dotProductScript = GetComponent<DotProductScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //access to option menu on escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttonHolderCanvas.gameObject.SetActive(true);
        }

        if (timer.timeUp && !gameOverCanvas.activeSelf)
        {
            buttonHolderCanvas.gameObject.SetActive(true);
            timeUpCanvas.gameObject.SetActive(true);
            gameOver = true;
        }

        //game over consequences - redundant and suitable for refactoring
        //if (dotProductScript.canSeePlayer == true)
        //{
        //    gameOverCanvas.gameObject.SetActive(true);
        //    buttonHolderCanvas.gameObject.SetActive(true);
       // }

       
    }

}
