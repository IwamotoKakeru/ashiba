using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンのロゴ
/// </summary>
public class Title : MonoBehaviour
{
    private int sceneNum;
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        // 右クリック
        if (Input.GetMouseButtonDown(0))
        {
            sceneNum++;
            SceneManager.LoadScene(sceneNum);
        }
    }
}
