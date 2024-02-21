using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フェードを行うスクリプト
/// Imageコンポーネントを持つオブジェクトにアタッチして使用
/// Canvas下に配置すること
/// </summary>
public class FadeManager : MonoBehaviour
{
    float fadeSpeed = 0.04f;
    float red, green, blue, alfa;
    Image fadeImage;

    /// <summary>
    /// 真なら自動でフェードインを行う
    /// </summary>
    public bool enableAutoFadeIn = true;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        if (enableAutoFadeIn) StartCoroutine(FadeInCorutine());
    }

    /// <summary>
    /// fadeImageを透明にしてフェードインする
    /// </summary>
    /// <param name="callback">フェードイン終了後に行う関数</param>
    /// <returns></returns>
    public IEnumerator FadeInCorutine(Action callback = null)
    {
        fadeImage.enabled = true;
        alfa = 1;
        while (alfa > 0)
        {
            alfa -= fadeSpeed;
            ApplyAlpha();
            yield return null;
        }
        fadeImage.enabled = false;
        callback?.Invoke();
        yield return null;
    }

    /// <summary>
    /// fadeImageを不透明にしてフェードアウトする
    /// </summary>
    /// <param name="callback">フェードアウト終了後に行う関数</param>
    /// <returns></returns>
    public IEnumerator FadeOutCorutine(Action callback = null)
    {
        fadeImage.enabled = true;
        alfa = 0;
        ApplyAlpha();
        while (alfa < 1)
        {
            alfa += fadeSpeed;
            ApplyAlpha();
            yield return null;
        }
        callback?.Invoke();
        yield return null;
    }

    /// <summary>
    /// alfaをfadeImageに反映させる
    /// </summary>
    void ApplyAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}


