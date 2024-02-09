using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Generator : MonoBehaviour
{
    public GameObject Square;
    private NumDisplay numDisplay;

    // インスペクタから取得するため自動実装プロパティのように扱う
    public int MaxGenerateNum = 3;
    private int maxGenerateNum = 1;
    private int generatedNum = 0;
    void Awake()
    {
        maxGenerateNum = MaxGenerateNum;
        numDisplay = GetComponentInChildren<NumDisplay>();
    }

    void Start()
    {
        numDisplay.ChangeNum(MaxGenerateNum);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (generatedNum < maxGenerateNum)
        {
            if (collision.gameObject.CompareTag(Tags.Cursor))
            {
                Instantiate(Square, this.transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
                generatedNum += 1;
                numDisplay.ChangeNum(maxGenerateNum - generatedNum);
            }
        }
    }
}
