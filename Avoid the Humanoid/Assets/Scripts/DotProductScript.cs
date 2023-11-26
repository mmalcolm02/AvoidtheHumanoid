using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProductScript : MonoBehaviour
{

    public float radius = 30.0f;
    public float distanceBetween;
    public float degreesSeen;
    public float dotOverMag;
    public PlayerController player;
    public GameObject enemy;
    public bool canSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        canSeePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //determine distance between player and enemy
        distanceBetween = Vector3.Distance(transform.position, player.transform.position);

        //determine forward facing vector of enemy
        Vector3 enemyForward = transform.forward;

        //determine vector between player and enemy
        Vector3 dirToPlayer = player.transform.position - transform.position;

        //determine the dot product and compare to cosValue
        float dot = Vector3.Dot(enemyForward, dirToPlayer);

        //determine magnitude calculation
        dotOverMag = dot / (Vector3.Magnitude(enemyForward) * Vector3.Magnitude(dirToPlayer));

        //Cosine calculations
        float visibility = Mathf.Cos(Mathf.Deg2Rad * (degreesSeen / 2));

        //check vision and range
        if (dotOverMag > visibility && distanceBetween <= radius)
        {
            canSeePlayer = true;
        }

    }
}
