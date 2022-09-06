using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square: MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float xInput = 0.0f;
    private float xSpeed = 5.0f;
    private bool isWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Walk(float xInput){
        if(xInput>0.0f){
            rb.velocity = new Vector2(xSpeed,rb.velocity.y);
            transform.localScale = new Vector3(1,1,1);
            isWalk = true;
        }
        else if(xInput<0.0f){
            rb.velocity = new Vector2(-xSpeed,rb.velocity.y);
            transform.localScale = new Vector3(-1,1,1);
            isWalk = true;
        }
        else{
            isWalk = false;
            rb.velocity = new Vector2(0.0f,rb.velocity.y);
        }
        anim.SetBool("walk",isWalk);
    }

    void Jamp(bool jampInput){

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Walk(Input.GetAxisRaw("Horizontal"));
    }

}
