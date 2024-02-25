using UnityEngine;

/// <summary>
/// シーン内のオブジェクトの何処か一つにアタッチすると早送り機能が使える
/// 暫定でCursorにアタッチ
/// </summary>
public class TimeCtrl : MonoBehaviour
{
    private const float defaultFastTimeScale = 4.0f;
    private const float defaultTimeScale = 1.0f;
    void Update()
    {
        FastFoward(Input.GetMouseButton(1));
    }

    /// <summary>
    /// 早送りかそうでないかを切り替える
    /// BGMも早送りさせる
    /// </summary>
    /// <param name="toggleFlag">真であれば早送り、偽であれば通常速度</param>
    /// <param name="fastTimeScale">早送りのスピード</param>
    public void FastFoward(bool toggleFlag, float fastTimeScale = defaultFastTimeScale)
    {
        if (toggleFlag)
        {
            Time.timeScale = fastTimeScale;
        }
        else
        {
            Time.timeScale = defaultTimeScale;
        }
    }

    /// <summary>
    /// 時間を一時停止する
    /// BGMは停止しない
    /// </summary>
    /// <param name="stopFlag"></param>
    public void StopTime(bool stopFlag)
    {
        if (stopFlag)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = defaultTimeScale;
        }
    }
}
