using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotational : MonoBehaviour
{

    public bool rotationTime = false;
    public int rotationAngle = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotationControl());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotationControl()
    {
        yield return new WaitForSeconds(3);
        transform.Rotate(0, (rotationAngle * -45), 0);
        rotationAngle = -rotationAngle;
        rotationTime = !rotationTime;
        StartCoroutine(RotationControl());


    }

    
}
