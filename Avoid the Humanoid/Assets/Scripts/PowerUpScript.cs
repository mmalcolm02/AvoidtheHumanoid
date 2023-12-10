using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public bool isOnGround;
    public bool hitGround = false;
    public float yOffset = 1.15f;
    public float watchPebble = 3;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y! <= yOffset)
        {
            isOnGround = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            hitGround = true;
            isOnGround = true;
            StartCoroutine("PebbleCoolDOwn");

        }
    }

    IEnumerator PebbleCoolDown()
    {
        yield return new WaitForSeconds(watchPebble);
        hitGround = false;
    }
}