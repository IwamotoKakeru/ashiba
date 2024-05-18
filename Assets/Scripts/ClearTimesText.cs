using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

/// <summary>
/// タイトルでクリア回数を表示する
/// </summary>
public class ClearTimesText : MonoBehaviour
{
    private Text text;
    private int clearTimes = -1;

    void Awake()
    {
        text = GetComponent<Text>();
#if UNITY_WEBGL && !UNITY_EDITOR
        clearTimes = WebGL.GetClearTimes();
#endif
        text.text = "クリア回数: " + clearTimes.ToString();
    }

    void Start()
    {
    }

}
