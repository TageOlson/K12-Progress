using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int scoreToIncrementBy)
    {
        score+=scoreToIncrementBy;
        scoreText.text = score.ToString();
    }
}
