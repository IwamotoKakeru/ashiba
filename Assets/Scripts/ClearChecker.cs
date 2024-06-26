﻿using System;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

/// <summary>
/// シーン上のすべてのゴールからクリア判定を行う
/// </summary>
/// 実装:岩本
public class ClearChecker : MonoBehaviour
{
    private List<Goal> goalsScripts = new();
    private bool goaledFlag = false;
    private int sceneNum;
    public GameObject clearLogoPrefab;
    private GameObject clearLogo;

    private GameObject fader;
    private FadeManager fade;

    public AudioClip clear;
    private AudioSource audioSource;

    private float intervalTime = 4.0f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //すべてのゴールスクリプトの取得
        //TODO: 重い処理のため要改善
        goalsScripts = FindObjectsOfType<Goal>().ToList();
        fader = GameObject.FindGameObjectWithTag(Utility.Tags.Fader);
        fade = fader.GetComponent<FadeManager>();

        clearLogo = Instantiate(clearLogoPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        clearLogo.SetActive(false);
    }

    bool ClearCheck()
    {
        return goalsScripts.All(goal => goal.ReturnGoalFlag());
    }

    void Update()
    {
        //TODO: 無駄に呼び出し回数が多い
        if (ClearCheck() && !goaledFlag)
        {
            // クリア時の処理
            goaledFlag = true;

            audioSource.PlayOneShot(clear);
            clearLogo.SetActive(true);

            goalsScripts.ToList().ForEach(goal => goal.DisableGoal());

            StartCoroutine(GoToNextScene());
        }
    }

    private IEnumerator GoToNextScene()
    {
        yield return new WaitForSeconds(intervalTime);
        StartCoroutine(fade.FadeOutCorutine(() => { SceneManager.LoadScene(sceneNum + 1); }));
        yield return null;
    }
}
