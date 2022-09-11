using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square: MonoBehaviour
{
    private string cursorTag = "GameController";

    //AudioCrips   
    public AudioClip jumpSE;

    //Components
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSC;

    //GameObjects
    public GroundCheck ground,ceiling;
    public GameObject corpse;
    private float gravity = 4.0f;

    private float walkSpeed = 2.0f;
    private float jumpSpeed = 3.0f;

    private bool isWalk = false;
    private bool isJump = false;
    private bool isGround = false;
    private bool isCeiling = false;

    //Jump variables
    private float jumpPos = 0.0f;   
    private float jumpHeight = 1.2f;   
    private float jumpTime = 0.0f;
    private float jumpMaxTime = 1.0f;
    public AnimationCurve jumpCurve;

    private float xSpeed,ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSC = GetComponent<AudioSource>();
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

        if(isGround && jumpInput>0.0f &&!isJump) audioSC.PlayOneShot(jumpSE);

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
            if(jumpInput > 0 && jumpHeight > transform.position.y - jumpPos && !isCeiling && jumpMaxTime>jumpTime){
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

    private float NumericRounder(float value){
        //小数点以下のみ取り出し
        float decimicalVal = value % 1;

        if(decimicalVal == 0.5f){
            return value;
        }else{
            return Mathf.Floor(value)+0.5f;
        }
    }

    //死体を丁度いい位置に生成する関数
    void RoundPositonInstantiate(){

        Vector3 instantPosition = transform.position;
        instantPosition.x = NumericRounder(instantPosition.x);
        instantPosition.y = NumericRounder(instantPosition.y);

        Instantiate(corpse,instantPosition,Quaternion.identity);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(cursorTag))
        {
            RoundPositonInstantiate();
            Destroy(this.gameObject);
        }
    }
    /*
    void FixedUpdate()
    {
        Initialize();

        Walk(Input.GetAxisRaw("Horizontal"));
        jump(Input.GetAxis("Vertical"));

    }
    */

}
