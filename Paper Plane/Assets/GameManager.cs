using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MicrophoneInput))]

public class GameManager : MonoBehaviour
{
    private float fallRate = 2.0f;
    private float speedMul = 4.8f;
    private bool isGameOver = false;
    public GameObject panelOver;
    private MicrophoneInput mic;

    // Start is called before the first frame update
    void Start()
    {
        panelOver.SetActive(false);
        mic = GetComponent<MicrophoneInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //we need to make sure that the plane will always fall when nothing happens
        Vector3 newPos = new Vector3(0, transform.position.y - fallRate * Time.deltaTime);
        if (Microphone.devices.Length > 0) //if we have a microphone
        {
            float level = mic.GetVolumeMic();
            newPos.y += (level * speedMul) * Time.deltaTime;
        }
        else //if no microphone, use keyboard
        {
            newPos.y += (Input.GetAxis("Vertical") * speedMul) * Time.deltaTime;
        }
        transform.position = newPos; //where the plane goes
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        fallRate = 15.0f; //make the plane drop quickly when it hits something
        if (!isGameOver)
        {
            isGameOver = true;
            //make sure the other scripts know that it is game over
            BroadcastMessage("isGameOver", SendMessageOptions.DontRequireReceiver); //forces the other scripts to have a parameter isGameOver but we don't want so set Don't Require receiver
            GameOver();
        }
    }

    void GameOver()
    {
        panelOver.SetActive(true);
    }
}
