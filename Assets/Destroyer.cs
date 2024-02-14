using Constants;
using UnityEngine;

/// <summary>
/// 画面外にでたオブジェクトを削除する
/// </summary>
public class Destroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {

        if (!collision.gameObject.CompareTag(Tags.Cursor))
        {
            Destroy(collision.gameObject);
        }

    }
}
