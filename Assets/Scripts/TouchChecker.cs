using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

/// <summary>
/// このスクリプトをアタッチしたオブジェクトがもつトリガーと特定のタグのトリガーとの重なりを完全に検知する
/// </summary>
public class TouchChecker : MonoBehaviour
{
    /// <summary>
    /// ObjectTagが返すタグをoverrideすることで他のタグに対応可能
    /// </summary>
    public virtual string ObjectTag => Tags.Block;
    private bool enterFlag, stayFlag, exitFlag;
    private bool isTouch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTag)) enterFlag = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTag)) stayFlag = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ObjectTag)) exitFlag = true;
    }

    /// <summary>
    /// 触れているかどうかを取得する
    /// </summary>
    /// <returns>触れているなら真</returns>
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
