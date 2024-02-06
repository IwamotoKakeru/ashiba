using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRollScript : MonoBehaviour
{
    public GameObject Logo;
    private bool LogoFlag = false;

    private Text tex;

    private int state = 0;
    private float intervalSecond = 6.0f;
    private float time = 5.0f;

    private string end = "おわり";
    private string staff1 = "スタッフ\n＜　けーる　＞\nグラフィック\nプログラミング";
    private string staff2 = "スタッフ\n＜　アダ　＞\nサウンド\nプログラミング";
    private string staff3 = "スタッフ\n＜　酢酸カーミン　＞\nプログラミング\nステージ制作";
    private string se = "スタッフ\n＜　chouette　＞\nプログラミング\nステージ制作\nデバッグ";
    private string company = "九州工業大学\nプログラミング研究会";

    private Vector3 logPos = new Vector3(0.0f, 1.6f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<Text>();
        StartCoroutine(RunEndRoll());
    }

    void ChangeText(string str)
    {
        tex.text = str;
    }

    IEnumerator RunEndRoll()
    {
        ChangeText(end);
        yield return new WaitForSeconds(intervalSecond);
        ChangeText(staff1);
        yield return new WaitForSeconds(intervalSecond);
        ChangeText(staff2);
        yield return new WaitForSeconds(intervalSecond);
        ChangeText(staff3);
        yield return new WaitForSeconds(intervalSecond);
        ChangeText(se);
        yield return new WaitForSeconds(intervalSecond * 3);
        Instantiate(Logo, logPos, Quaternion.identity);
        ChangeText(company);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("title");
    }
}
