using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpriteRendererを所持しているオブジェクトにこのスクリプトをアタッチするとホバーが実装される
/// </summary>
public class Hover : TouchChecker
{
    private string cursorTag = "Hover";

    public override string ObjectTag => cursorTag;

    private SpriteRenderer spriteRenderer;
    private Color hoverColor = new Color(0.8f, 0.8f, 0.8f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (IsTouching())
        {
            spriteRenderer.color = hoverColor;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }

    }
}
