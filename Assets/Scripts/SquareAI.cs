using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Walking,
    Jumping,
    Falling,

}

public class SquareAI : MonoBehaviour
{
    // Start is called before the first frame update
    private State currentState = State.Walking;
    private bool alongWallFlag = false;
    private float walkSpeed = 1.0f;
    private float jumpSpeed = 1.0f;


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
        if (isWall) currentState = State.Jumping;

        // 空中にいるとき
        if (!isGround) currentState = State.Falling;
    }
    void FixedUpdate()
    {
        InitializeFlag();

        switch (currentState)
        {
            case State.Walking:
                Sq.Walk(walkSpeed);
                Sq.jump(0.0f);

                // 壁に接したら
                if (isWall) currentState = State.Jumping;

                // 空中にいるとき
                if (!isGround) currentState = State.Falling;
                break;

            case State.Jumping:
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
                        currentState = State.Walking;
                    }
                }
                // ジャンプが終わっても壁があったら反転
                else if (isGround && isWall && alongWallFlag)
                {
                    alongWallFlag = false;
                    walkSpeed = -walkSpeed;
                    currentState = State.Walking;
                }

                break;

            case State.Falling:
                Sq.Walk(0.0f);
                Sq.jump(0.0f);
                // 接地したら歩く
                if (isGround) currentState = State.Walking;
                break;

            default:
                //nothing
                break;
        }
    }
}
