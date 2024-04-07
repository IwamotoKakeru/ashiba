using UnityEngine;

/// <summary>
/// キャラクター専用のホバー
/// クリックされれば死体が生成されるであろう位置に仮想的なオブジェクトを配置
/// </summary>
public class CharaHover : Hover
{
    public GameObject hoverPrefab;
    private GameObject hoverObject;

    //TODO: ホバーオブジェクトを生成するタイミングのせいでエラーが発生している
    void Awake()
    {
        hoverObject = Instantiate(hoverPrefab);
        hoverObject.SetActive(false);
    }

    protected override void SetHover()
    {
        base.SetHover();
        hoverObject.SetActive(true);
    }

    protected override void UnsetHover()
    {
        base.UnsetHover();
        hoverObject.SetActive(false);
    }

    void Update()
    {
        if (hoverObject.activeSelf)
        {
            // 死体が生成されるであろう位置にオブジェクトを配置
            hoverObject.transform.position = Utility.Stage.GetRoundedPos(this.transform.position);
        }
    }

    void OnDisable()
    {
        Debug.Log(hoverObject);
        if (hoverObject.activeSelf)
            hoverObject.SetActive(false);
    }

}
