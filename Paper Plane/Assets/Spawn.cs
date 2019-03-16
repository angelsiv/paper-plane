using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //we'll need 3 variables
    public float startTime = 1.0f; //it will take after 1 sec
    public float loopTime = 4.0f; //loop at every 4 seconds
    public GameObject[] pipes; //list of things we wanna spawn

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawning", startTime, loopTime); //repeatidly invokes a method at loopTime
    }

    //instantiate a random pipe at the spawner's position and rotation
    void Spawning()
    {
        int rand = Random.Range(0, pipes.Length);
        Instantiate(pipes[rand], transform.position, transform.rotation);
    }
}
