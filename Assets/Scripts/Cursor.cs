using UnityEngine;
using Utility;

/// 実装:岩本
/// <summary>
/// ゲーム内カーソルをマウスに追従させる
/// </summary>
public class Cursor : MonoBehaviour
{
    private Vector3 mousePosition, target;

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (WebGL.CheckTouchDevice())
        {
            GetComponent<Cursor>().enabled = false;
        }
#endif
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        target = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = target;
    }
}
