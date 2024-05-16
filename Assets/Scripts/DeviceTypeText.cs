using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utility;

/// <summary>
/// タイトルでデバイス種別を表示するためのスクリプト
/// </summary>
public class DeviceTypeText : MonoBehaviour
{
    private Text text;
    private string deviceType = "PC";

    void Awake()
    {
        text = GetComponent<Text>();
#if UNITY_WEBGL && !UNITY_EDITOR
        deviceType = WebGL.GetDeviceType();
#endif
    }

    void Start()
    {
        text.text = "Device: " + deviceType;
    }

}
