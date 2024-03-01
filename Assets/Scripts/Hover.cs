using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// マウスが重なった際のホバー
/// SpriteRendererとコライダー2Dを所持しているオブジェクトにこのスクリプトをアタッチするとホバーが実装される
/// </summary>
/// 実装:岩本
public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private SpriteRenderer spriteRenderer;
    private Color hoverColor = new Color(0.6f, 0.8f, 0.6f);

    protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void SetHover()
    {
        spriteRenderer.color = hoverColor;
    }

    protected virtual void UnsetHover()
    {
        spriteRenderer.color = Color.white;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        SetHover();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        UnsetHover();
    }
}
