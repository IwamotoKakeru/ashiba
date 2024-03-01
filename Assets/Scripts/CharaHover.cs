using UnityEngine;

/// <summary>
/// キャラクター専用のホバー
/// </summary>
public class CharaHover : Hover
{
    public GameObject virtualObject;

    void Start()
    {
        Instantiate(virtualObject);
    }

    protected override void SetHover()
    {
        base.SetHover();
        Debug.Log("set");
    }

    protected override void UnsetHover()
    {
        base.UnsetHover();
        Debug.Log("unset");
    }

}
