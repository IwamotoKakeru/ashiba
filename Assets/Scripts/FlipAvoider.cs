using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 親のスケールが反転した際に子が反転しないように表示されるようにするためのコンポーネント
/// 反転してほしくない子オブジェクトにアタッチする
/// </summary>
public class FlipAvoider : MonoBehaviour
{
    void Update()
    {
        var parentLossyScale = this.transform.parent.lossyScale;
        var tempLocalScale = this.transform.localScale;

        // もし親が負なら
        if (parentLossyScale.x <= -0.0f)
        {
            // 自分も負に
            tempLocalScale.x = -Math.Abs(tempLocalScale.x);
            transform.localScale = tempLocalScale;
        }
        else
        {
            // 負でなければ自分を正に
            tempLocalScale.x = Math.Abs(tempLocalScale.x);
            transform.localScale = tempLocalScale;
        }
    }
}
