using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square: MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public GroundCheck ground,ceiling;
    private float gravity = 4.0f;

    private float walkSpeed = 5.0f;
    private float jumpSpeed = 3.0f;

    private bool isWalk = false;
    private bool isJump = false;
    private bool isGround = false;
    private bool isCeiling = false;

    private float jumpPos = 0.0f;   
    private float jumpHeight = 1.2f;   
    private float jumpTime = 0.0f;
    public AnimationCurve jumpCurve;

    private float xSpeed,ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Initialize(){
        isGround = ground.IsGround();
        isCeiling = ceiling.IsGround();
        xSpeed = 0.0f;
        if(isGround)    ySpeed = 0.0f;
        else            ySpeed = -gravity;
    }

    public void Walk(float walkInput){
        if(walkInput>0.0f){
            xSpeed = walkSpeed;
            transform.localScale = new Vector3(1,1,1);
            isWalk = true;
        }
        else if(walkInput<0.0f){
            xSpeed = -walkSpeed;
            transform.localScale = new Vector3(-1,1,1);
            isWalk = true;
        }
        else{
            xSpeed = 0.0f;
            isWalk = false;
        }
        anim.SetBool("walk",isWalk);
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    public void jump(float jumpInput){

        if(isGround){
            if (jumpInput>0){
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
                jumpTime = 0.0f;
            }
            else{
                isJump = false;
            }
        }else if(isJump){
            if(jumpInput > 0 && jumpHeight > transform.position.y - jumpPos && !isCeiling ){
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else{
                isJump = false;
                jumpTime = 0.0f;
            }
        }
        if(isJump)  ySpeed *= jumpCurve.Evaluate(jumpTime);
        anim.SetBool("isGround",isGround);
        rb.velocity = new Vector2(rb.velocity.x, ySpeed);
    }

    // Update is called once per frame
    /*
    void FixedUpdate()
    {
        Initialize();

        Walk(Input.GetAxisRaw("Horizontal"));
        jump(Input.GetAxis("Vertical"));

    }
    */

}
