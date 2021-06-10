using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeKeeper : MonoBehaviour
{
    Text livesText;
    [SerializeField] int lives = 3;
    [SerializeField] Vector3 respawnPosition;
    [SerializeField] GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        livesText.text = lives.ToString();
    }

    public void DecreaseLives()
    {
        --lives;
        livesText.text = lives.ToString();
        if(lives > 0)
        {
            var newPlayer = Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
        }
    }
}
