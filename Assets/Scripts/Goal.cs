using UnityEngine;
using Constants;

/// <summary>
/// ゴール用のスクリプト
/// </summary>
/// 実装:岩本
public class Goal : MonoBehaviour
{
    public AudioClip goal;
    public AudioSource audioSource;

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
    }

    public bool ReturnGoalFlag()
    {
        if (goalNum == 0) return true;
        else return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            goalNum--;
            collision.gameObject.SetActive(false);
            audioSource.PlayOneShot(goal);
            numDisplay.DisplayInt(goalNum);
        }
    }
}
