using UnityEngine;

/// <summary>
/// シーン内のオブジェクトの何処か一つにアタッチすると早送り機能が使える
/// 暫定でCursorにアタッチ
/// </summary>
public class TimeCtrl : MonoBehaviour
{
    private const float defaultFastTimeScale = 4.0f;
    private const float defaultTimeScale = 1.0f;

    private BgmManager bgmManager;

    void Start()
    {
        // テストシーンなどでBgmManagerが存在しないときに備える
        try
        {
            bgmManager = GameObject.Find("BgmManager").GetComponent<BgmManager>();
        }
        catch (System.NullReferenceException e)
        {
            bgmManager = null;
            Debug.Log(e);
            Debug.Log("BgmManagerが見つからなかったためbgmManagerをnullとして扱います");
        }
    }
    void Update()
    {
        // 1 は右クリック
        // Unity側のKeyCodeで定義がないのでハードコードしている
        FastFoward(Input.GetMouseButton(1));
    }

    /// <summary>
    /// 早送りかそうでないかを切り替える
    /// BGMも早送りさせる
    /// </summary>
    /// <param name="toggleFlag">真であれば早送り、偽であれば通常速度</param>
    /// <param name="fastTimeScale">早送りのスピード</param>
    public void FastFoward(bool toggleFlag, float fastTimeScale = defaultFastTimeScale)
    {
        if (toggleFlag)
        {
            Time.timeScale = fastTimeScale;
            // TODO: null条件演算子はUnityでは非推奨であるため修正する
            bgmManager?.SetPitch(fastTimeScale);
        }
        else
        {
            Time.timeScale = defaultTimeScale;
            bgmManager?.SetPitch();
        }
    }

    /// <summary>
    /// 時間を一時停止する
    /// BGMは停止しない
    /// </summary>
    /// <param name="stopFlag"></param>
    public void StopTime(bool stopFlag)
    {
        if (stopFlag)
        {
            Time.timeScale = 0;
            bgmManager?.SetPitch();
        }
        else
        {
            Time.timeScale = defaultTimeScale;
        }
    }
}
