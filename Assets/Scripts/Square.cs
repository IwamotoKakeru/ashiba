using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square: MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public GroundCheck ground,ceiling;
    private float gravity = 5.0f;

    private float walkSpeed = 5.0f;
    private float jumpSpeed = 5.0f;

    private bool isWalk = false;
    private bool isJump = false;
    private bool isGround = false;
    private bool isCeiling = false;

    private float jumpPos = 0.0f;   
    private float jumpHeight = 3.0f;   
    private float xSpeed,ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Initialize(){
        isGround = ground.IsGround();
        isCeiling = ceiling.IsGround();
        xSpeed = 0.0f;
        if(isGround)    ySpeed = 0.0f;
        else            ySpeed = -gravity;
    }

    void Walk(float walkInput){
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
    }

    void Jamp(float jampInput){

        if(isGround){
            if (jampInput>0){
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
            }
            else{
                isJump = false;
            }
        }else if(isJump){
            if(jampInput > 0 && jumpHeight > transform.position.y - jumpPos && !isCeiling ){
                ySpeed = jumpSpeed;
            }
            else{
                isJump = false;
            }
        }
        anim.SetBool("isGround",isGround);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Initialize();

        Walk(Input.GetAxisRaw("Horizontal"));
        Jamp(Input.GetAxis("Vertical"));

        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

}
