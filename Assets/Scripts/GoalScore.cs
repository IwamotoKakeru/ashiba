using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class GoalScore : MonoBehaviour
{

    public GameObject score_object = null;
    public string score_num; //スコア変数

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = score_num;
    }
}
