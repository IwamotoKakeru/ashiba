using System;
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

        // もし親が左向きなら
        if (parentLossyScale.x <= -0.0f)
        {
            // 自分も左向きに
            tempLocalScale.x = -Math.Abs(tempLocalScale.x);
            transform.localScale = tempLocalScale;
        }
        else
        {
            // 親が右向きなら自分も右向きに
            tempLocalScale.x = Math.Abs(tempLocalScale.x);
            transform.localScale = tempLocalScale;
        }
    }
}
