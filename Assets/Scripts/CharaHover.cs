using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CharaHover : Hover
{
    public GameObject virtualObject;

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
