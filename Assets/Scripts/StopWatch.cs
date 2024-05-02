using UnityEngine;
using System;


/// <summary>
/// 経過時間を表示する
/// </summary>
public class StopWatch : MonoBehaviour
{
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    System.TimeSpan timeSpan;

    private StringDisplay stringDisplay;
    void Start()
    {
        sw.Start();
        stringDisplay = GetComponentInChildren<StringDisplay>();
    }

    void Update()
    {
        stringDisplay.DisplayString(sw.Elapsed.ToString(@"mm\:ss\.ff"));
    }
}
