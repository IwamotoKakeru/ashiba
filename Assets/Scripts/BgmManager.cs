using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 全ステージのBGMを管理する
/// シングルトンを用いている
/// </summary>
public class BgmManager : MonoBehaviour
{
    private static bool dontDestroyEnabled = false;

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


    private AudioSource audioSource;

    public AudioClip stage;
    public AudioClip ending;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        //エディター上でBGMを流すために使用
        PlayBgm(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// ステージが変わった際にBGMを途切れさせずに再生する
    /// </summary>
    void CountinuPlay()
    {
        // 再生されていなければ再生
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void PlayBgm(int buildIndex)
    {
        if (buildIndex == (int)Constants.SceneIndex.Title)
        {
            //タイトル
            audioSource.Stop();
        }
        else if (buildIndex == (int)Constants.SceneIndex.Ending)
        {
            //エンディング
            audioSource.clip = ending;
            CountinuPlay();
        }
        else
        {
            //ステージ
            audioSource.clip = stage;
            CountinuPlay();
        }
    }

    //シーンが切り替わった瞬間に呼ばれるメソッド　
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        PlayBgm(nextScene.buildIndex);
    }

    /// <summary>
    /// BGMの速さを変更する
    /// </summary>
    /// <param name="pitch">速度</param>
    public void ChangePitch(float pitch = 1.0f)
    {
        audioSource.pitch = pitch;
    }


    /// <summary>
    /// 右クリックした際にBGMも早送りに
    /// </summary>
    void Update()
    {
        ChangePitch(Time.timeScale);
    }

}
