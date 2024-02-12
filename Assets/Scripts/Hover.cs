using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// SpriteRendererを所持しているオブジェクトにこのスクリプトをアタッチするとホバーが実装される
/// </summary>
public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private SpriteRenderer spriteRenderer;
    private Color hoverColor = new Color(0.6f, 0.8f, 0.6f);

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        spriteRenderer.color = hoverColor;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.color = Color.white;
    }
}
