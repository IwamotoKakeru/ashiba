using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndRollScript : MonoBehaviour
{
    //　テキストのスクロールスピード
    [SerializeField]
    private float textScrollSpeed = 30;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 730f;
    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;
    //　シーン移動用コルーチン
    private Coroutine endRollCoroutine;
    public GameObject logo;

    // Update is called once per frame
    void Update()
    {
        //　エンドロールが終了した時
        if (isStopEndRoll) {
            endRollCoroutine = StartCoroutine(GoToNextScene());
        } else {
            //　エンドロール用テキストがリミットを越えるまで動かす
            if (transform.position.y <= limitPosition) {
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            } else {
                isStopEndRoll = true;
                Instantiate(logo,new Vector3(0,1.0f,0),Quaternion.identity);
            }
        }
    }

    IEnumerator GoToNextScene() {
        //　5秒間待つ
        yield return new WaitForSeconds(5f);

        if(Input.GetMouseButtonDown(0)) {
            StopCoroutine(endRollCoroutine);
            SceneManager.LoadScene(0);
        }

        yield return null;
    }
}
