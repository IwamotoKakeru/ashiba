using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareAI : MonoBehaviour
{
    // Start is called before the first frame update
    Square Sq ;
    public GroundCheck ground,ceiling,wall;

    private bool isGround,isCeiling,isWall;

    void Start()
    {
        Sq = gameObject.GetComponent<Square>();
    }

    void Initialize(){
        isGround = ground.IsGround();
        isCeiling = ceiling.IsGround();
        isWall = wall.IsGround();
        Sq.Initialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Initialize();
        Sq.Walk(Input.GetAxisRaw("Horizontal"));
        Sq.jump(Input.GetAxis("Vertical"));
    }
}
