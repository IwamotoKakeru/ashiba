using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン上のすべてのゴールからクリア判定を行う
/// </summary>
/// 実装:岩本
public class GoalGeneral : MonoBehaviour
{
    private Goal[] goalsScripts;
    private bool goalFlags;
    private bool instantFlag = false;
    private int sceneNum;
    public GameObject clearLogo;

    private float intervalTime = 4.0f;

    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //すべてのゴールスクリプトの取得
        goalsScripts = FindObjectsOfType<Goal>();
    }

    void GoalCheck()
    {
        goalFlags = true;
        foreach (Goal goalScript in goalsScripts)
        {
            goalFlags &= goalScript.ReturnGoalFlag();
        }

    }

    void Update()
    {
        GoalCheck();
        if (goalFlags && !instantFlag)
        {
            Instantiate(clearLogo, new Vector3(0, 0, 0), Quaternion.identity);
            Invoke("GoToNextScene", intervalTime);
            instantFlag = true;
        }
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(sceneNum + 1);
    }
}
