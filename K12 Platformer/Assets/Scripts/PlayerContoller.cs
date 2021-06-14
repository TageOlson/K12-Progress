using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    Collider2D myCollider;
    Rigidbody2D myRigidbody;
    LifeKeeper theLifeKeeper;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] float fallSpeedMultiplier = 1.5f;
    [SerializeField] float jumpSpeedMultiplier = 1.25f;
    [Range(0, 0.05f)] [SerializeField] float jumpDamping = 0.005f;
    bool isGrounded = false;
    private Vector2 StartPos;

    // Start is called before the first frame update
    void Start()
    {
        myCollider= GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        theLifeKeeper = FindObjectOfType<LifeKeeper>();
        StartPos = myRigidbody.position;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        Run();
        Jump();
        SmoothJumping();
    }
    private void Run()
    {
        float controlDirection = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(myRigidbody.velocity.x, myRigidbody.velocity.y);
        if(!isGrounded)
        { //less movement in air
            playerVelocity.x += (controlDirection * runSpeed * .3f *jumpDamping);
            //Debug.Log(playerVelocity.x);
            playerVelocity.x = Mathf.Lerp(playerVelocity.x, 0f, .5f * jumpDamping);//prevents horizontal movement from going too far in the air
        }
        else
        {
            playerVelocity.x = controlDirection * runSpeed;
        }
        playerVelocity.x = Mathf.Clamp(playerVelocity.x, -runSpeed, runSpeed);
        //playerVelocity.y = Mathf.Clamp(playerVelocity.y, 10 * -runSpeed, 10 * runSpeed); //limiting fall speed
        myRigidbody.velocity = playerVelocity;
    }
    private void Jump()
    {
        if(!isGrounded)
        {
            return;
        }
        if(Input.GetButtonDown("Jump")) // spacebar
        {
            myRigidbody.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void SmoothJumping()
    {
        if(myRigidbody.velocity.y < 0)
        {//faster falling
            myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * fallSpeedMultiplier * Time.deltaTime;
        }
        else if(myRigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {//moving up and not holding jump, short hop
            myRigidbody.velocity += Vector2.up * Physics2D.gravity.y * jumpSpeedMultiplier * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        theLifeKeeper.DecreaseLives();
        myRigidbody.position = StartPos;
        //Destroy(gameObject);
    }
    private void GroundCheck()
    {
        isGrounded = myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
}
