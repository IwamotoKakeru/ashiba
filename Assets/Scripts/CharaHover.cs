using UnityEngine;

/// <summary>
/// キャラクター専用のホバー
/// </summary>
public class CharaHover : Hover
{
    public GameObject hoverPrefab;
    private GameObject hoverObject;

    new void Start()
    {
        base.Start();
        hoverObject = Instantiate(hoverPrefab);
        hoverObject.SetActive(false);
    }

    protected override void SetHover()
    {
        base.SetHover();
        hoverObject.SetActive(true);
        Debug.Log("set");
    }

    protected override void UnsetHover()
    {
        base.UnsetHover();
        hoverObject.SetActive(false);
        Debug.Log("unset");
    }

    void Update()
    {
        if (hoverObject.activeSelf)
        {
            hoverObject.transform.position = Utility.Stage.GetRoundedPos(this.transform.position);
        }
    }

}
