using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

/// <summary>
/// タッチできるデバイスか否かでテキストを切り替える
/// </summary>
public class TextSwitcher : MonoBehaviour
{
    private Text text;

    private bool touchableDevice = false;

    [SerializeField] private string touchDeviceText;
    [SerializeField] private string clickDeviceText;

    void Awake()
    {
        text = GetComponent<Text>();
#if UNITY_WEBGL && !UNITY_EDITOR
        touchableDevice = WebGL.CheckTouchDevice();
#endif
    }

    void Start()
    {
        if (touchableDevice)
        {
            text.text = touchDeviceText;
        }
        else
        {
            text.text = clickDeviceText;
        }
    }

}
