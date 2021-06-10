using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerKeeper : MonoBehaviour
{
    Text timerText;
    [SerializeField] float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            //Debug.Log("TIMER DONE!");
            timerText.text = "Game Over";
            DestroyPlayer();
        }
        else
        {
            time -= Time.deltaTime;
            int timerVal = (int)time;
           // Debug.Log(timerVal);
           timerText.text = "Time Remaining: " + timerVal;
        }
    }

    private void DestroyPlayer()
    {
        PlayerContoller player = FindObjectOfType<PlayerContoller>();
        if (player != null)
        {
        Destroy(player.gameObject);
        }
    }
}
