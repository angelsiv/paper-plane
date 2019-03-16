using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text txtScore;
    public string preText = "SCORE: ";
    private float score = 0.0f;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime * 100;
            int scoreDisplay = (int)Mathf.Round(score); //calculates in float, but converted to int
            txtScore.text = preText + scoreDisplay.ToString("D8");
        }
    }

    void GameOver()
    {
        isGameOver = true;
    }
}
