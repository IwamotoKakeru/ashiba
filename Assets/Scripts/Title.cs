using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンのロゴ
/// </summary>
public class Title : MonoBehaviour
{
    private int sceneNum;
    
    public GameObject Fader;
    FadeManager fade;
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        fade = Fader.GetComponent<FadeManager>();
    }

    void Update()
    {
        // 右クリック
        if (Input.GetMouseButtonDown(0))
        {
            sceneNum++;
            StartCoroutine(fade.FadeOutCorutine(() => SceneManager.LoadScene(sceneNum)));
        }
    }
}
