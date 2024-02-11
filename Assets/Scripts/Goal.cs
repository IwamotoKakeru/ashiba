using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Goal : MonoBehaviour
{
    public AudioClip goal;
    public AudioSource audioSource;

    public int goalNumGetter = 1;
    private int goalNum = 1;
    private StringDisplay numDisplay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        numDisplay = GetComponentInChildren<StringDisplay>();
        goalNum = goalNumGetter;
        numDisplay.ChangeNum(goalNumGetter);
    }

    public int returnGoalNum()
    {
        return goalNum;
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
