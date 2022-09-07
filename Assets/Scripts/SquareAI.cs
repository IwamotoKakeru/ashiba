using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareAI : MonoBehaviour
{
    // Start is called before the first frame update
    private int state = 1;
    private bool flag = false;

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
        //Sq.Walk(Input.GetAxisRaw("Horizontal"));
        //Sq.jump(Input.GetAxis("Vertical"));

        switch(state){
            case 1:
                Sq.Walk(1.0f);
                Sq.jump(0.0f);
                if(isWall) state = 2;
                break;

            case 2:
                Sq.Walk(0.0f);
                Sq.jump(1.0f);
                if(isWall && !isGround) flag = true;

                if(!isWall){
                    Sq.Walk(1.0f);
                    Sq.jump(1.0f);
                    if(isGround) state = 1;
                }
                else if(isGround && isWall && flag){
                    state = 3;
                    flag = false;
                } 
             
                break;

            case 3:
                Sq.Walk(-1.0f);
                Sq.jump(0.0f);

                if(isWall) state = 4;
            
                break;
            
            case 4:
                Sq.Walk(0.0f);
                Sq.jump(1.0f);
                if(isWall && !isGround) flag = true;

                if(!isWall){
                    Sq.Walk(-1.0f);
                    Sq.jump(1.0f);
                    if(isGround) state = 3;
                }
                else if(isGround && isWall && flag)
                 state = 1;
                flag = false;
                break;
            
            
            default:
                //nothing
                break;
        }

        /*
        if(isGround == false) Sq.Walk(0.0f);
        if(isWall == true) {
            Sq.Walk(0.0f);
            Sq.jump(1.0f);
        }else{
            Sq.Walk(1.0f);
            Sq.jump(0.0f);
        }*/

    }
}
