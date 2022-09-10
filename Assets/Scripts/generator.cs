using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class generator : MonoBehaviour
{
    public GameObject Square;
    public int MaxPlayer = 3;
    private int numOfPlayer;
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
        if(numOfPlayer<MaxPlayer)
        {
            if (collision.gameObject.CompareTag(cursorTag))
            {
            Instantiate(Square, this.transform.position+new Vector3(0,-1.0f,0), Quaternion.identity);
            numOfPlayer +=1;
            }
        }
    }
}
