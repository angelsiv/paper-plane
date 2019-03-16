using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    private float speed = 1.5f;

    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x - speed * Time.deltaTime, 0); //the only one we move is the x value
        transform.position = newPos;

        //when it's out of the screen, destroy gameobject pipe
        if (transform.position.x < -5.0f) 
        {
            Destroy(gameObject); 
        }
    }
}
