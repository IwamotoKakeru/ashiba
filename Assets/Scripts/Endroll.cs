using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// 実装:岩本
/// <summary>
/// エンドロール時に実行されるスクリプト
/// </summary>
public class Endroll : MonoBehaviour
{
    public GameObject Logo;

    private Text tex;

    private float intervalSecond = 6.0f;
    private string[] creditArray = new string[]
    {
        "おわり",
        "スタッフ\n＜　乗算記号　＞\n企画\nプログラミング",
        "スタッフ\n＜　くだもん　＞\nグラフィック",
        "スタッフ\n＜　アダ　＞\nサウンド\nプログラミング",
        "スタッフ\n＜　酢酸カーミン　＞\nプログラミング\nステージ制作",
        "スタッフ\n＜　chouette　＞\nプログラミング\nステージ制作\nデバッグ",
    };
    private string company = "九州工業大学\nプログラミング研究会";

    private Vector3 logoPos = new Vector3(0.0f, 1.6f, 0.0f);

    void Start()
    {
        tex = GetComponent<Text>();
        StartCoroutine(RunEndroll());
    }

    void ChangeText(string str)
    {
        tex.text = str;
    }

    IEnumerator RunEndroll()
    {
        foreach (string credit in creditArray)
        {
            ChangeText(credit);
            yield return new WaitForSeconds(intervalSecond);
        }
        Instantiate(Logo, logoPos, Quaternion.identity);
        ChangeText(company);
        yield return new WaitForSeconds(intervalSecond * 3);
        SceneManager.LoadScene("title");
    }
}
