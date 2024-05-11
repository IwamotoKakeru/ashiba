using System.Runtime.InteropServices;
using UnityEngine;

/// 実装:岩本
/// <summary>
/// ゲーム内カーソルをマウスに追従させる
/// </summary>
public class Cursor : MonoBehaviour
{
    [DllImport("__Internal")] private static extern bool CheckTouchDevice();

    private Vector3 mousePosition, target;

    protected bool CheckWebGLPlatform()
    {
        return Application.platform == RuntimePlatform.WebGLPlayer;
    }

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (CheckTouchDevice())
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
