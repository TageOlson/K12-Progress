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
        transform.position = Vector3.MoveTowards(transform.position, newPos, SmoothingSpeed * Time.deltaTime);
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
    public void SnapTo()
    {
        transform.position = new Vector3(RB_followObject.position.x+DeadZone.x, RB_followObject.position.y+DeadZone.y,transform.position.z);
    }
}
