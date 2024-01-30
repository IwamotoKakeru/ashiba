using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public AudioClip goal;
    public AudioSource audioSource;

    public int goalNumGetter = 1;
    private int goalNum = 1;
    private NumDisplay numDisplay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        numDisplay = GetComponentInChildren<NumDisplay>();
        goalNum = goalNumGetter;
        numDisplay.DisplayNum(goalNumGetter);
    }

    public int returnGoalNum()
    {
        return goalNum;
    }

    // Update is called once per frame

    public bool returnGoalFlag()
    {
        if (goalNum == 0) return true;
        else return false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            goalNum--;
            Debug.Log("1体ゴール");
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(goal);
            if (goalNum == 0) Debug.Log("全体ゴール");
            numDisplay.DisplayNum(goalNum);
        }

    }
}
