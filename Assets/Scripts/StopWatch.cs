using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

/// <summary>
/// 経過時間を表示するタイマーを管理する
/// 複数シーンをまたぐためシングルトンを用いる
/// </summary>
public class StopWatch : MonoBehaviour
{
    static bool dontDestroyEnabled = false;

    System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

    StringDisplay stringDisplay;

    //シングルトン設定
    void Awake()
    {
        if (dontDestroyEnabled)
        {
            Destroy(gameObject);
        }
        dontDestroyEnabled = true;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        stringDisplay = GetComponentInChildren<StringDisplay>();
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった瞬間に呼ばれるメソッド　
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        ToggleCtrl(nextScene.buildIndex);
    }

    void ToggleCtrl(int buildIndex)
    {
        switch ((SceneIndex)buildIndex)
        {
            case SceneIndex.Turtorial:
                stopWatch.Start();
                break;

            case SceneIndex.Ending:
                stopWatch.Stop();
                break;

            case SceneIndex.Title:
                stopWatch.Reset();
                break;

            default:
                // ステージ
                break;
        }
    }

    void Update()
    {
        // TODO: Update内で呼び出だすとボトルネックになる可能性があるので改善する
        stringDisplay.DisplayString(stopWatch.Elapsed.ToString(@"mm\:ss\.ff"));
    }
}
