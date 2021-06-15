using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Vector3 startingPosition;
    float direction;
    [SerializeField] float maxMovementDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {   startingPosition = transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if(currentPosition.x <= startingPosition.x)
        {
            direction = 1f;
        }
        else if (currentPosition.x >= startingPosition.x + maxMovementDistance)
        {
            direction = -1f;
        }
        
        myRigidbody.velocity = new Vector2(direction, 0);
    }
    private void OnDrawGizmos()
    {
        Vector3 currentPosition= transform.position;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x+maxMovementDistance,transform.position.y,transform.position.z), new Vector3(.25f,.25f,1));
        Gizmos.DrawWireCube(transform.position, new Vector3(.25f,.25f,1));  
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x+maxMovementDistance,transform.position.y,transform.position.z)); 

    }
}
