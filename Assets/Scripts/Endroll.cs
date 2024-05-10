using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utility;
using unityroom.Api;

/// 実装:岩本
/// <summary>
/// エンドロール時に実行されるスクリプト
/// </summary>
public class Endroll : MonoBehaviour
{
    public GameObject Logo;
    private System.Diagnostics.Stopwatch stopWatch;

    private Text tex;

    private float intervalSecond = 6.0f;
    // private float blinkingSecond = .5f;
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
    private string clearTimeText;

    private Vector3 logoPos = new Vector3(0.0f, 1.6f, 0.0f);

    void Start()
    {
        tex = GetComponent<Text>();

        stopWatch = GameObject.Find("StopWatch").GetComponent<StopWatch>().stopWatch;
        float totalSec = (float)(stopWatch.Elapsed.TotalMilliseconds / 1000);

        clearTimeText = "クリアタイム\n" + stopWatch.Elapsed.ToString(@"mm\:ss\.ff") + "\nCongratulation!!!\n";
        clearTimeText += totalSec.ToString() + "秒としてランキングに掲載しました";

#if UNITY_EDITOR
        // 何もしない
        // エディター上で実行した際のタイムを登録しないようにするため
#else
        // unityroomのランキングへ登録
        UnityroomApiClient.Instance.SendScore(1, totalSec, ScoreboardWriteMode.HighScoreDesc);
#endif

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

        Destroy(Instantiate(Logo, logoPos, Quaternion.identity), intervalSecond);
        ChangeText(company);
        yield return new WaitForSeconds(intervalSecond);

        // クリアタイムを点滅させる
        // for (int i = 0; i < 8; i++)
        // {
        //     ChangeText(clearTimeText);
        //     yield return new WaitForSeconds(blinkingSecond);
        //     ChangeText("");
        //     yield return new WaitForSeconds(blinkingSecond);
        // }

        ChangeText(clearTimeText);
        yield return new WaitForSeconds(intervalSecond * 2);

        SceneManager.LoadScene((int)SceneIndex.Title);
    }
}
