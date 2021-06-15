using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckup : MonoBehaviour
{
    ScoreKeeper theScoreKeeper;
    [Range(1, 100)][SerializeField] int pointValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        theScoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            theScoreKeeper.IncreaseScore(pointValue);
            Destroy(gameObject);
        }
    }
}
