using UnityEngine;

/// <summary>
/// ゲーム内カーソルをマウスに追従させる
/// </summary>
public class Cursor : MonoBehaviour
{
    private Vector3 mousePosition, target;

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        target = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = target;
    }
}
