using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public float carSpeed;
    public GameObject diedCanvas;
    public GameObject buttonHolderCanvas;

    // Ensure car prefab only has a short lifetime
    void Start()
    {
        StartCoroutine(DestroyCar());
    }

    

    //Movement
    void Update()
    {

        transform.Translate(Vector3.down * carSpeed * Time.deltaTime);
    }

    //Lifetime determined by coroutine
    IEnumerator DestroyCar()
    {
    yield return new WaitForSeconds(2);
        Destroy(gameObject);
}
}
