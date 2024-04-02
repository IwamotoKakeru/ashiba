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
    public GameObject clearLogoPrefab;
    private GameObject clearLogo;
    private GameObject fader;
    private FadeManager fade;

    private float intervalTime = 4.0f;


    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //すべてのゴールスクリプトの取得
        //重い処理のため要改善
        goalsScripts = FindObjectsOfType<Goal>();
        fader = GameObject.FindGameObjectWithTag(Utility.Tags.Fader);
        fade = fader.GetComponent<FadeManager>();

        clearLogo = Instantiate(clearLogoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        clearLogo.SetActive(false);
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
        clearLogo.SetActive(true);
        yield return new WaitForSeconds(intervalTime);
        StartCoroutine(fade.FadeOutCorutine(() => { SceneManager.LoadScene(sceneNum + 1); }));
        yield return null;
    }
}
