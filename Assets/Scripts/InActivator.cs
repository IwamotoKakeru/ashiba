using Constants;
using UnityEngine;

/// <summary>
/// 画面外にでたオブジェクトを非アクティブにする
/// </summary>
/// 実装:岩本
public class InActivator : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag(Tags.Cursor))
        {
            collision.gameObject.SetActive(false);
        }

    }
}
