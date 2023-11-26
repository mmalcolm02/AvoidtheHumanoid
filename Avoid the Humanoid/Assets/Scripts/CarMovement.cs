using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float carSpeed;
    public GameObject diedCanvas;
    public GameObject buttonHolderCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * carSpeed * Time.deltaTime);
    }
    

}
