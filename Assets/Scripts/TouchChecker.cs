using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchChecker : MonoBehaviour
{
    private string objectTag = "Block";
    private bool enterFlag, stayFlag, exitFlag;
    private bool isTouch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag)) enterFlag = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag)) stayFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag)) exitFlag = true;
    }

    public bool IsTouching()
    {
        if (enterFlag || stayFlag) isTouch = true;
        else if (exitFlag) isTouch = false;

        enterFlag = false;
        stayFlag = false;
        exitFlag = false;

        return isTouch;
    }
}
