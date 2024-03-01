using UnityEngine;

enum State
{
    Walking,
    Jumping,
    Falling,
}

/// <summary>
/// キャラクターを制御するAI
/// </summary>
public class CharaAI : MonoBehaviour
{
    private State currentState = State.Walking;
    private bool alongWallFlag = false;
    private float walkDirection = 1.0f;
    private float walkVelocity = 1.0f;
    private readonly float walkInput = 1.0f;
    private readonly float jumpInput = 1.0f;

    CharaBase Sq;
    public TouchChecker ground, ceiling, wall;

    private bool isGround, isWall;

    void Start()
    {
        Sq = gameObject.GetComponent<CharaBase>();
    }

    void Initialize()
    {
        walkVelocity = walkDirection * walkInput;
        isGround = ground.IsTouching();
        isWall = wall.IsTouching();
        Sq.Initialize();
    }

    /// <summary>
    /// 壁まで歩き、壁に当たるとジャンプし、飛び越えられなければ反転する
    /// </summary>
    void WalkAndJumpProgress()
    {
        switch (currentState)
        {
            case State.Walking:
                Sq.Walk(walkVelocity);
                Sq.Jump(0.0f);

                // 壁に接したら
                if (isWall) currentState = State.Jumping;

                // 空中にいるとき
                if (!isGround) currentState = State.Falling;
                break;

            case State.Jumping:
                // 真上にジャンプ
                Sq.Walk(0.0f);
                Sq.Jump(jumpInput);
                if (isWall && !isGround) alongWallFlag = true;

                // 壁がなければ右入力しながらジャンプ
                if (!isWall)
                {
                    Sq.Walk(walkVelocity);
                    Sq.Jump(jumpInput);
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
                    walkDirection = -walkDirection;
                    currentState = State.Walking;
                }
                break;

            case State.Falling:
                Sq.Walk(0.0f);
                Sq.Jump(0.0f);
                // 接地したら歩く
                if (isGround) currentState = State.Walking;
                break;

            default:
                //nothing
                break;
        }
    }

    void FixedUpdate()
    {
        Initialize();
        WalkAndJumpProgress();
    }
}
