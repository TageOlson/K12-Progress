using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followObject;
    private Rigidbody2D RB_followObject;
    [SerializeField] Vector2 followOffset;
    private Vector2 DeadZone;
    [Range(1f, 10f)][SerializeField] float SmoothingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        DeadZone = findZone();
        RB_followObject = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector2 follow = followObject.transform.position;
        float xDiff = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDiff = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPos = transform.position;
        //check if followObject is outside of our dead zone
        float camSpeed = RB_followObject.velocity.magnitude > SmoothingSpeed ? RB_followObject.velocity.magnitude : SmoothingSpeed; 
        if(Mathf.Abs(xDiff)>= DeadZone.x)
        {
            newPos.x =follow.x;
        }
        if(Mathf.Abs(yDiff)>= DeadZone.y)
        {
            newPos.y = follow.y;
        }
      // newPos.x = Mathf.Lerp(transform.position.x, newPos.x, SmoothingSpeed * Time.deltaTime);
      // newPos.y = Mathf.Lerp(transform.position.y, newPos.y, camSpeed * Time.deltaTime);
        //       
        transform.position = Vector3.MoveTowards(transform.position, newPos, SmoothingSpeed * Time.deltaTime);
        //float yPos, yNew;
        //float xPos, xNew;
        //Mathf.MoveTowards(xPos, xNew, SmoothingSpeed * Time.deltaTime);
        //Vector3 targetPos = RB_followObject.position + followOffset;
        //targetPos.z = -10f;
        
        //Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, SmoothingSpeed *Time.fixedDeltaTime);
        //transform.position = targetPos;
    }
    private Vector3 findZone()
    {
        Rect aspectRatio = Camera.main.pixelRect;
        Vector2 CamDimensions = new Vector2(Camera.main.orthographicSize * aspectRatio.width / aspectRatio.height, Camera.main.orthographicSize);
        //offset the camera from the object
        CamDimensions.x -= followOffset.x;
        CamDimensions.y -= followOffset.y;
        return CamDimensions;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector2 border = findZone();
        Gizmos.DrawWireCube(transform.position, new Vector3(2 * border.x, 2 * border.y, 1));

    }
}
