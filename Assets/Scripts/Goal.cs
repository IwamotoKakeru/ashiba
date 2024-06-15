using UnityEngine;
using Utility;

/// <summary>
/// ゴール用のスクリプト
/// </summary>
/// 実装:岩本
public class Goal : MonoBehaviour
{
    public AudioClip goal;
    public AudioClip badGoal;
    public AudioSource audioSource;
    public GameObject clearEffectPrefab;
    private GameObject clearEffectObject;

    public int goalNumGetter = 1;// 変数名が規則違反だが、変更するとインスペクタ上の値をすべて変更する必要があるため保留
    private int goalNum = 1;
    private StringDisplay numDisplay;

    // numDisplayに正常に表示させるため、Awakeで数値を取得し、Startで反映させる
    void Awake()
    {
        numDisplay = GetComponentInChildren<StringDisplay>();
        goalNum = goalNumGetter;

    }
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        numDisplay.DisplayInt(goalNum);

        clearEffectObject = Instantiate(clearEffectPrefab);
        clearEffectObject.SetActive(false);
    }

    public bool ReturnGoalFlag()
    {
        if (goalNum == 0) return true;
        else return false;
    }

    public void DisableGoal()
    {
        Debug.Log("A Goal Disabled");
        clearEffectObject.transform.position = this.gameObject.transform.position;
        clearEffectObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void PlayGoalSound()
    {
        if (goalNum >= 0)
        {
            audioSource.PlayOneShot(goal);
        }
        else
        {
            audioSource.PlayOneShot(badGoal);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            goalNum--;
            collision.gameObject.SetActive(false);
            PlayGoalSound();
            if (goalNum > 0)
            {
                numDisplay.DisplayInt(goalNum);
            }
            else if (goalNum == 0)
            {
                numDisplay.DisplayInt(goalNum, ColorUtility.ToHtmlStringRGB(Color.yellow));
            }
            else
            {
                numDisplay.DisplayInt(goalNum, ColorUtility.ToHtmlStringRGB(Color.red));
            }
        }
    }
}
