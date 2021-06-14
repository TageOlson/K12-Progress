using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayPlatformController : MonoBehaviour
{
    private PlatformEffector2D p_eff2D;
    [SerializeField] float pause = 0;
    [SerializeField] int fallFlag = 0;

    // Start is called before the first frame update
    void Start()
    {
        p_eff2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.DownArrow))
        {
            fallFlag = 1;
            pause = 0.2f;
            p_eff2D.rotationalOffset = 180f * fallFlag;
        }
        else if (fallFlag == 1)
        {
            if(pause <= 0)
            {
                fallFlag = 0;
                p_eff2D.rotationalOffset = 180f * fallFlag;
            }
            pause -= Time.deltaTime;
        }
    }
}
