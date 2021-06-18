using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool isActive = true;
    [SerializeField] bool isLevelEnd = false;
    TimerKeeper timeKeeper;
    PlayerContoller player;
    LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        timeKeeper = FindObjectOfType<TimerKeeper>();
        player = FindObjectOfType<PlayerContoller>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
        {//increase time and deactivate
            if(isLevelEnd)
            {
                //end level
                FindObjectOfType<AudioManager>().PlaySound("Teleport");
                levelLoader.LoadNextLevel();
            }
            else if(isActive)
            {
                isActive = false;
                timeKeeper.AddTime(15);
                player.RespawnPosition = transform.position;
                FindObjectOfType<AudioManager>().PlaySound("Chime");
            }
        }

    }
}
