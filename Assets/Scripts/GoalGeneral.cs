using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン上のすべてのゴールからクリア判定を行う
/// </summary>
/// 実装:岩本
public class GoalGeneral : MonoBehaviour
{
    private Goal[] goalsScripts;
    private bool goaledFlag = false;
    private int sceneNum;
    public GameObject clearLogo;
    private GameObject fader;
    private FadeManager fade;

    private float intervalTime = 4.0f;


    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //すべてのゴールスクリプトの取得
        //重い処理のため要改善
        goalsScripts = FindObjectsOfType<Goal>();
        fader = GameObject.FindGameObjectWithTag(Constants.Tags.Fader);
        fade = fader.GetComponent<FadeManager>();
    }

    bool GoalCheck()
    {
        bool goalFlags = true;
        foreach (Goal goalScript in goalsScripts)
        {
            goalFlags &= goalScript.ReturnGoalFlag();
        }
        return goalFlags;
    }

    void Update()
    {
        if (GoalCheck() && !goaledFlag)
        {
            goaledFlag = true;
            StartCoroutine(GoToNextScene());
        }
    }

    private IEnumerator GoToNextScene()
    {
        Instantiate(clearLogo, new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(intervalTime);
        StartCoroutine(fade.FadeOutCorutine(() => { SceneManager.LoadScene(sceneNum + 1); }));
        yield return null;
    }
}
