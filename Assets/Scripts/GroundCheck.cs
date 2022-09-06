using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Block";
    private bool enterFlag,stayFlag,exitFlag;
    private bool isGround = false;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.tag == groundTag)  enterFlag = true;
    }

    private void OnTriggerStay2D(Collider2D collison)
    {
        if (collison.tag == groundTag)  stayFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collison)
    {
        if (collison.tag == groundTag)  exitFlag = true;
    }

    public bool IsGround(){
        if(enterFlag || stayFlag) isGround = true;
        else if(exitFlag)         isGround = false;

        enterFlag = false;
        stayFlag = false;
        exitFlag = false;

        return isGround;
    }
}
