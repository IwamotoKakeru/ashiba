using UnityEngine;

/// <summary>
/// キャラがブロックに囲まれているかどうかチェックする
/// TrapedCheckerにアタッチする
/// </summary>
public class TrapedChecker : MonoBehaviour
{
    private TouchChecker[] touchCheckers;
    void Start()
    {
        touchCheckers = GetComponentsInChildren<TouchChecker>();
    }

    /// <summary>
    /// 囲まれているかどうかを返す
    /// </summary>
    /// <returns>囲まれているなら真</returns>
    public bool CheckTraped()
    {
        foreach (var touchChecker in touchCheckers)
        {
            if (!touchChecker.IsTouching()) return false;
        }
        return true;
    }
}
