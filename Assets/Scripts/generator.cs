using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class generator : MonoBehaviour
{
    public GameObject Square;
    private NumDisplay numDisplay;
    public int MaxPlayerGetter = 3;
    private int MaxPlayer =1;
    private int numOfPlayer = 0;
    private string cursorTag = "GameController";
    // Start is called before the first frame update
    void Awake()
    {
        MaxPlayer = MaxPlayerGetter;
        numDisplay = GetComponentInChildren<NumDisplay>();
        
    }
    void Start()
    {
       numDisplay.DisplayNum(MaxPlayerGetter);
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(numOfPlayer<MaxPlayer)
        {
            if (collision.gameObject.CompareTag(cursorTag))
            {
                Instantiate(Square, this.transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
                numOfPlayer += 1;
                numDisplay.DisplayNum(MaxPlayer - numOfPlayer);
            }
        }
    }
}
