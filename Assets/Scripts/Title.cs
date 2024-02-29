using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンのロゴ
/// </summary>
public class Title : MonoBehaviour
{
    public GameObject Fader;
    FadeManager fade;
    void Start()
    {
        fade = Fader.GetComponent<FadeManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(fade.FadeOutCorutine(() => SceneManager.LoadScene((int)Constants.SceneIndex.Turtorial)));
        }
    }
}
