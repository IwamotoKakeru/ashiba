using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

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


    public AudioSource StageBgm;
    public AudioSource EndingBgm;

    void Start()
    {
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        //エディター上でBGMを流すために使用
        ChangeBgm(SceneManager.GetActiveScene().buildIndex);
    }

    void CountinuPlay(AudioSource audioSource)
    {
        // 再生されていなければ再生
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void ChangeBgm(int buildIndex)
    {
        if (buildIndex == 0)
        {
            //タイトル
            StageBgm.Stop();
            EndingBgm.Stop();
            Debug.Log("Title");
        }
        else if (buildIndex == 10)
        {
            //エンディング
            StageBgm.Stop();
            EndingBgm.Play();
            Debug.Log("Into Ending");
        }
        else
        {
            //ステージ
            CountinuPlay(StageBgm);
            EndingBgm.Stop();
            Debug.Log("Into Stage");
        }
    }

    //シーンが切り替わった瞬間に呼ばれるメソッド　
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        ChangeBgm(nextScene.buildIndex);
    }

}
