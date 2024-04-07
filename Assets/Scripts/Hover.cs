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
    private Color disableColor = new Color(0.5f, 0.5f, 0.5f);

    protected void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// カーソルがオブジェクトに重なった際に呼ばれる
    /// </summary>
    protected virtual void SetHover()
    {
        spriteRenderer.color = hoverColor;
    }

    /// <summary>
    /// カーソルがオブジェクトからはなれた際に呼ばれる
    /// </summary>
    protected virtual void UnsetHover()
    {
        spriteRenderer.color = Color.white;
    }

    /// <summary>
    /// ホバーを無効化するときに呼ぶ
    /// 色を変更するとともにこのコンポーネントを無効化する
    /// </summary>
    public void SetDisable()
    {
        spriteRenderer.color = disableColor;
        this.enabled = false;
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
