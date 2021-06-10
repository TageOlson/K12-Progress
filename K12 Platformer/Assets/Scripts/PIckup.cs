using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckup : MonoBehaviour
{
    ScoreKeeper theScoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        theScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        theScoreKeeper.IncreaseScore();
        Destroy(gameObject);
    }
}
