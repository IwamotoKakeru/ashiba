using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Goal : MonoBehaviour
{
    public AudioClip goal;
    public AudioSource audioSource;

    public int goalNumGetter = 1;// 変数名が規則違反だが、変更するとインスペクタ上の値を変更する必要があるため保留
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
        numDisplay.ChangeNum(goalNum);
    }

    public bool returnGoalFlag()
    {
        if (goalNum == 0) return true;
        else return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Player))
        {
            goalNum--;
            Debug.Log("1体ゴール");
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(goal);
            if (goalNum == 0) Debug.Log("全体ゴール");
            numDisplay.ChangeNum(goalNum);
        }
    }
}
