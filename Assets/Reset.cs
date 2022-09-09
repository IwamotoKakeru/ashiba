using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private string cursorTag = "GameController";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(cursorTag))
        {
           SceneManager.LoadScene(0);
        }
    }
}
