using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public AudioClip goal;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("ゴール");
                audioSource.PlayOneShot(goal);
            }
        
    }
}
