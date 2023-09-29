using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove;
    public float speed = 3f;

    Rigidbody2D myBody;

    bool grounded = true;

    public float castDist = 1f;

    public float jumpPower = 2f;
    public float gravityScale = 5f;
    public float gravityFall = 40f;

    public bool jump = true;

    //Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        //myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            //myAnim.SetBool("Jumping", true);
            jump = true;
        }

        if (horizontalMove > 0.2f || horizontalMove < -0.2f)
        {
            //myAnim.SetBool("RUnning", true);
        }
        else
        {
            //myAnim.SetBool("RUnning", false);
        }

    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        if (myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;
        }
        else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        //if (hit.collider != null && hit.transform.name == "Ground")
        if (hit.collider != null && hit.transform.tag == "Ground")
        {
            //myAnim.SetBool("Jumping", false);
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0f);
    }
}
