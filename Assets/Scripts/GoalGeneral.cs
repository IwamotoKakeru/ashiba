using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalGeneral : MonoBehaviour
{
    // Start is called before the first frame update
    private Goal[] goalsScripts;
    private bool goalFlags;
    void Start()
    {
        //すべてのゴールスクリプトの取得
        goalsScripts = Goal.FindObjectsOfType<Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        goalFlags = true;
        foreach(Goal goalScript in goalsScripts){
            goalFlags &= goalScript.returnGoalFlag();
        }

        if(goalFlags) Debug.Log("全部ゴール!");
    }
}
