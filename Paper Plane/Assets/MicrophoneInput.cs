using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour
{
    private AudioClip micInput;
    private bool micInitialized;

    void Awake()
    {
        if(Microphone.devices.Length > 0) //we have to make sure we have at least one microphone
        {
            micInput = Microphone.Start(Microphone.devices[0], true, 10, 44100); //pick first mic and start recording
            micInitialized = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetVolumeMic()
    {
        //if no microphone, then this script won't work
        if (!micInitialized) 
        {
            return 0;
        }

        int dec = 128; //take 128 frequencies and analyze this
        float[] waveData = new float[dec];
        int offsetSample = Microphone.GetPosition(null) - (dec + 1); //null will let Microphone take the first microphone or default one

        //populate the data array
        micInput.GetData(waveData, offsetSample);

        float level = 0.0f; // by default, 0 sound
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            //find what is the peak
            if(level < wavePeak)
            {
                level = wavePeak;
            }
        }

        float lvl = Mathf.Sqrt(Mathf.Sqrt(level)); //gives you a value between 0 and 1, maths is very magical
        if (lvl < 0.5f)
        {
            lvl = 0.0f; //if too low, set it as 0
        }
        return lvl;
    }
}
