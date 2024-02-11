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
    /// 整数を1桁で表示する
    /// </summary>
    /// <param name="displayNum">表示する整数</param>
    public void DisplayInt(int displayNum)
    {
        num = displayNum;
        textMesh.text = num.ToString("0");
    }

    /// <summary>
    /// 文字列を表示する
    /// </summary>
    /// <param name="displayNum">表示する文字列</param>
    public void DisplayString(string displayString)
    {
        textMesh.text = displayString;
    }
}
