using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private AsyncOperation async;
    private AudioClip microphoneInput;

    public void Awake() //happens before start
    {
        //initialize microphone, make sure there exists a microphone
        if(Microphone.devices.Length > 0)//if I have at least one microphone, then I will start recording
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 1, 4410); //use first microhpone you find, then record in loop for 1sec at the default frequency of most microphones
            Microphone.End(Microphone.devices[0]); //this 1sec recording prompts to the user to allow microphone use
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        async = SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        async.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame() //attach to button to allow scene to be activated
    {
        async.allowSceneActivation = true;
    }
}
