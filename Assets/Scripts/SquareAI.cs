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
                if(!isGround) state = 5;
                break;

            case 2:
                Sq.Walk(0.0f);
                Sq.jump(1.0f);
                if(isWall && !isGround) flag = true;

                if(!isWall){
                    Sq.Walk(1.0f);
                    Sq.jump(1.0f);
                    if(isGround){
                    state = 1;
                    flag = false;
                    }
                    else if(isWall) {
                        state = 1;
                        flag = false;
                    }
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
                if(!isGround) state = 6;
            
                break;
            
            case 4:
                Sq.Walk(0.0f);
                Sq.jump(1.0f);
                if(isWall && !isGround) flag = true;

                if(!isWall){
                    Sq.Walk(-1.0f);
                    Sq.jump(1.0f);
                    if(isGround) {
                        state = 3;
                        flag = false;
                    }
                    else if(isWall) {
                        state = 3;
                        flag = false;
                    }
                }
                else if(isGround && isWall && flag){
                    state = 1;
                    flag = false;
                }
                break;
            
            case 5:
                Sq.Walk(0.0f);
                Sq.jump(0.0f);
                if(isGround) state = 1;
                break;
            
            case 6: 
                Sq.Walk(0.0f);
                Sq.jump(0.0f);
                if(isGround) state = 3;
                break;
            
            
            default:
                //nothing
                break;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           if(state == 1) state = 3;
           else if(state == 3) state = 1; 
        }
    }

}
