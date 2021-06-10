using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    Collider2D myCollider;
    Rigidbody2D myRigidbody;
    LifeKeeper theLifeKeeper;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        myCollider= GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        theLifeKeeper = FindObjectOfType<LifeKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }
    private void Run()
    {
        float controlDirection = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlDirection * runSpeed,
            myRigidbody.velocity.y);
            myRigidbody.velocity = playerVelocity;
    }
    private void Jump()
    {
        if(!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(Input.GetButtonDown("Jump")) // spacebar
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f,jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        theLifeKeeper.DecreaseLives();
        Destroy(gameObject);
    }
}
