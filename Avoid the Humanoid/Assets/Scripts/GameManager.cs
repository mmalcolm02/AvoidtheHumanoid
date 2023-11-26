using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DotProductScript dotProductScript;
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
        //option menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttonHolderCanvas.gameObject.SetActive(true);
        }

        if (timer.timeUp)
        {
            buttonHolderCanvas.gameObject.SetActive(true);
            timeUpCanvas.gameObject.SetActive(true);
            gameOver = true;
        }

        //game over consequences
        if (dotProductScript.canSeePlayer == true)
        {
            gameOverCanvas.gameObject.SetActive(true);
            buttonHolderCanvas.gameObject.SetActive(true);
        }

       
    }

}
