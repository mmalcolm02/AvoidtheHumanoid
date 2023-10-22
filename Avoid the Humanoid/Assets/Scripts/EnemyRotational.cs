using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotational : MonoBehaviour
{

   
    public float angleOfRotation = -45.0f;
    public float rotationDelay = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotationControl());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //coroutine to rotate the enemy back and forth every seconds equal to rotationDelay
    IEnumerator RotationControl()
    {
        yield return new WaitForSeconds(rotationDelay);
        transform.Rotate(0, (angleOfRotation), 0);
        angleOfRotation = -angleOfRotation;
        StartCoroutine(RotationControl());


    }

    
}
