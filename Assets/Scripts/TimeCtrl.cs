using UnityEngine;

/// <summary>
/// シーン内のオブジェクトの何処か一つにアタッチすると早送り機能が使える
/// 暫定でCursorにアタッチ
/// </summary>
public class TimeCtrl : MonoBehaviour
{
    [SerializeField] private float fastTimeScale = 4.0f;
    void Update()
    {
        ToggleTimeScale(Input.GetMouseButton(1));
    }

    void ToggleTimeScale(bool toggleFlag)
    {
        if (toggleFlag)
        {
            Time.timeScale = fastTimeScale;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

    }
}
