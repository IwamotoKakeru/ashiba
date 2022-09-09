using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class generator : MonoBehaviour
{
    public GameObject Square;
    private string cursorTag = "GameController";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(cursorTag))
        {
           Instantiate(Square, new Vector2(-6.5f,1.5f), Quaternion.identity);
        }
    }
}
