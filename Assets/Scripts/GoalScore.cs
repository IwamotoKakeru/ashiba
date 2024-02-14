using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゴール用のスコアを表示する
/// </summary>
[Obsolete("StrignDisplayの使用を推奨")]
public class GoalScore : MonoBehaviour
{
    public GameObject score_object = null;
    public string score_num; //スコア変数

    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = score_num;
    }
}
