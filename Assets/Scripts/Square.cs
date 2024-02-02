using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private string cursorTag = "GameController";

    //AudioCrips   
    public AudioClip jumpSE;

    //Components
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSC;

    //GameObjects
    public GroundCheck ground, ceiling;
    public GameObject corpse;

    private float gravity = 4.0f;

    private float walkSpeed = 2.0f;
    private float jumpSpeed = 3.0f;

    private bool isWalk = false;
    private bool isJumping = false;
    private bool isGround = false;
    private bool isCeiling = false;

    //Jump variables
    private float jumpPos = 0.0f;
    private float maxJumpHeight = 1.2f;
    private float jumpTime = 0.0f;
    private float maxJumpTime = 1.0f;
    public AnimationCurve jumpCurve;

    private float xSpeed, ySpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSC = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Squareの初期化を行う
    /// Squareを使用する際にUpdateの始めに必ず呼び出す
    /// </summary>
    public void Initialize()
    {
        isGround = ground.IsGround();
        isCeiling = ceiling.IsGround();
        xSpeed = 0.0f;
        if (isGround) ySpeed = 0.0f;
        else ySpeed = -gravity;
    }

    /// <summary>
    /// Squareを歩行させる
    /// </summary>
    /// <param name="walkInput">正なら右方向、負なら左方向、0なら静止</param>
    public void Walk(float walkInput)
    {
        if (walkInput > 0.0f)
        {
            xSpeed = walkSpeed;
            transform.localScale = new Vector3(1, 1, 1);
            isWalk = true;
        }
        else if (walkInput < 0.0f)
        {
            xSpeed = -walkSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
            isWalk = true;
        }
        else
        {
            xSpeed = 0.0f;
            isWalk = false;
        }
        anim.SetBool("walk", isWalk);
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    /// <summary>
    /// Squareをジャンプさせる
    /// JumpHeightまでジャンプした後は接地するまで下降する
    /// ジャンプボタンでジャンプしている感覚に近い
    /// </summary>
    /// <param name="jumpInput">正ならジャンプ動作を行う</param>
    public void Jump(float jumpInput)
    {

        if (isGround && jumpInput > 0.0f && !isJumping) audioSC.PlayOneShot(jumpSE);

        // 地上にいる際
        if (isGround)
        {
            if (jumpInput > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJumping = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJumping = false;
            }
        }
        // 空中にいる際
        else if (isJumping)
        {
            float jumpHeight = transform.position.y - jumpPos;
            if (jumpInput > 0 && maxJumpHeight > jumpHeight && !isCeiling && maxJumpTime > jumpTime)
            {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            }
            else
            {
                isJumping = false;
                jumpTime = 0.0f;
            }
        }
        if (isJumping) ySpeed *= jumpCurve.Evaluate(jumpTime);
        anim.SetBool("isGround", isGround);
        rb.velocity = new Vector2(rb.velocity.x, ySpeed);
    }

    private float NumericRounder(float value)
    {
        //小数点以下のみ取り出し
        float decimicalVal = value % 1;

        if (decimicalVal == 0.5f)
        {
            return value;
        }
        else
        {
            return Mathf.Floor(value) + 0.5f;
        }
    }

    //死体を丁度いい位置に生成する関数
    void RoundPositonInstantiate()
    {

        Vector3 instantPosition = transform.position;
        instantPosition.x = NumericRounder(instantPosition.x);
        instantPosition.y = NumericRounder(instantPosition.y);

        Instantiate(corpse, instantPosition, Quaternion.identity);

    }

    // クリックされた際の挙動
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(cursorTag))
        {
            RoundPositonInstantiate();
            Destroy(this.gameObject);
        }
    }

}
