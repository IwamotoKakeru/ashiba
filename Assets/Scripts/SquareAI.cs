using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Nothing,
    WalkRight,
    JumpRight,
    WalkLeft,
    JumpLeft,
    FallingToRight,
    FallingToLeft,

}

public class SquareAI : MonoBehaviour
{
    // Start is called before the first frame update
    private State state = State.WalkRight;
    private bool alongWallFlag = false;

    Square Sq;
    public GroundCheck ground, ceiling, wall;

    private bool isGround, isCeiling, isWall;

    void Start()
    {
        Sq = gameObject.GetComponent<Square>();
    }

    void InitializeFlag()
    {
        isGround = ground.IsGround();
        isCeiling = ceiling.IsGround();
        isWall = wall.IsGround();
        Sq.Initialize();
    }

    // Update is called once per frame

    void walking(float walkSpeed)
    {
        Sq.Walk(walkSpeed);
        Sq.jump(0.0f);

        // 壁に接したら
        if (isWall) state = State.JumpRight;

        // 空中にいるとき
        if (!isGround) state = State.FallingToRight;
    }
    void FixedUpdate()
    {
        float walkSpeed = 1.0f;
        float jumpSpeed = 1.0f;

        InitializeFlag();

        //Sq.Walk(Input.GetAxisRaw("Horizontal"));
        //Sq.jump(Input.GetAxis("Vertical"));

        switch (state)
        {
            case State.WalkRight:
                Sq.Walk(walkSpeed);
                Sq.jump(0.0f);

                // 壁に接したら
                if (isWall) state = State.JumpRight;

                // 空中にいるとき
                if (!isGround) state = State.FallingToRight;
                break;

            case State.JumpRight:
                // 真上にジャンプ
                Sq.Walk(0.0f);
                Sq.jump(jumpSpeed);
                if (isWall && !isGround) alongWallFlag = true;

                // 壁がなければ右入力しながらジャンプ
                if (!isWall)
                {
                    Sq.Walk(walkSpeed);
                    Sq.jump(jumpSpeed);
                    // 接地したら再び歩く
                    if (isGround)
                    {
                        alongWallFlag = false;
                        state = State.WalkRight;
                    }
                }
                // ジャンプが終わっても壁があったら反転
                else if (isGround && isWall && alongWallFlag)
                {
                    alongWallFlag = false;
                    state = State.WalkLeft;
                }

                break;

            case State.FallingToRight:
                Sq.Walk(0.0f);
                Sq.jump(0.0f);
                // 接地したら歩く
                if (isGround) state = State.WalkRight;
                break;

            case State.WalkLeft:
                Sq.Walk(-walkSpeed);
                Sq.jump(0.0f);

                if (isWall) state = State.JumpLeft;
                if (!isGround) state = State.FallingToLeft;

                break;

            case State.JumpLeft:
                Sq.Walk(0.0f);
                Sq.jump(jumpSpeed);
                if (isWall && !isGround) alongWallFlag = true;

                if (!isWall)
                {
                    Sq.Walk(-walkSpeed);
                    Sq.jump(jumpSpeed);
                    if (isGround)
                    {
                        state = State.WalkLeft;
                        alongWallFlag = false;
                    }
                }
                else if (isGround && isWall && alongWallFlag)
                {
                    state = State.WalkRight;
                    alongWallFlag = false;
                }
                break;


            case State.FallingToLeft:
                Sq.Walk(0.0f);
                Sq.jump(0.0f);
                if (isGround) state = State.WalkLeft;
                break;


            default:
                //nothing
                break;
        }
    }
}
