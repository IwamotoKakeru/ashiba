using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalGeneral : MonoBehaviour
{
    // Start is called before the first frame update
    private Goal[] goalsScripts;
    private bool goalFlags;
    private bool instantFlag = false;
    private int sceneNum ;
    public GameObject clearLogo;

    private float intervalTime = 4.0f;
    private float fastScale=4.0f;

    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //すべてのゴールスクリプトの取得
        goalsScripts = Goal.FindObjectsOfType<Goal>();
    }

    void GoalCheck(){
        goalFlags = true;
        foreach(Goal goalScript in goalsScripts){
            goalFlags &= goalScript.returnGoalFlag();
        }

    }

    void Update()
    {
        GoalCheck();
        if(goalFlags&&!instantFlag){
            Instantiate(clearLogo,new Vector3(0,0,0),Quaternion.identity);
            Invoke("GoToNextScene",intervalTime);
            instantFlag = true;
        }
        if(Input.GetMouseButton(1)){
            Time.timeScale = fastScale;
        }else{
            Time.timeScale = 1.0f;
        }
    }

    void GoToNextScene(){
        SceneManager.LoadScene(sceneNum+1);    
    }
}
