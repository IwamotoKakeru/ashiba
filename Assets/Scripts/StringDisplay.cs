using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringDisplay : MonoBehaviour
{
    private TextMesh textMesh;
    private int num;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    /// <summary>
    /// 表示する数字を変更する
    /// </summary>
    /// <param name="displayNum">表示する数字</param>
    public void ChangeNum(int displayNum)
    {
        num = displayNum;
        textMesh.text = num.ToString("0");
    }

    void Update()
    {
        // textMesh.text = num.ToString("0");
    }

}
