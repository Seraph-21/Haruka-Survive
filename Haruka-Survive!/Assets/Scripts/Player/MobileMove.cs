using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float moveSpeed = 80;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] bool allowKeyControls = true;
    [Tooltip("true if the game is a top down, flase if its a  platformer")]
    [SerializeField] bool isTopDown = true;
     new Collider2D collider;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] Canvas mobileCanvas;
    Animator myAnimator1;
    CapsuleCollider2D myCapsuleCollider;
    public bool playerHasHorizontalSpeed;
 


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        if (allowKeyControls)
        {
            mobileCanvas.enabled = false;
        }
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator1 = GetComponent<Animator>();
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(0,0);
        if (allowKeyControls)
        {
            move.x = Input.GetAxis("Horizontal");
            move.y = Input.GetAxis("Vertical");
            bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
             

            myAnimator1.SetBool("isRunning", playerHasHorizontalSpeed);
           

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
               
            }
          
        }
        else
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;
            bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
            myAnimator1.SetBool("isRunning", playerHasHorizontalSpeed);
        }
        if (isTopDown)
        {
            rb2d.velocity = new Vector3(joystick.Horizontal * moveSpeed, joystick.Vertical * moveSpeed, 0);
        }
        else
        {
            rb2d.velocity = new Vector3(move.x * moveSpeed, move.y * moveSpeed);
        }
        FlipSprite();
    }
    public void Jump()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")) && !isTopDown)
        {
            rb2d.AddForce(new Vector2(0, 20 * jumpForce));

        }
    }
    public void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2d.velocity.x), 1f);
        }
    }
}
