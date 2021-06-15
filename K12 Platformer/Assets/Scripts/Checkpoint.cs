using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool isActive = true;
    [SerializeField] bool isLevelEnd = false;
    TimerKeeper timeKeeper;
    PlayerContoller player;
    // Start is called before the first frame update
    void Start()
    {
        timeKeeper = FindObjectOfType<TimerKeeper>();
        player = FindObjectOfType<PlayerContoller>();
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
        {//increase time and deactivate
            if(isActive)
            {
                isActive = false;
                timeKeeper.AddTime(15);
                player.RespawnPosition = transform.position;
            }
            if(isLevelEnd)
            {
                //end level
            }
        }

    }
}
