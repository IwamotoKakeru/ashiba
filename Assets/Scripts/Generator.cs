using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class Generator : TouchChecker
{
    // 検知するタグをカーソルに変更
    public override string ObjectTag => Tags.Cursor;

    public GameObject Square;
    private StringDisplay numDisplay;

    // インスペクタから取得するため自動実装プロパティのように扱う
    public int MaxGenerateNum = 3;
    private int maxGenerateNum = 1;
    private int generatedNum = 0;

    private float intervalSec = 3.0f;
    private Vector3 generateLocalPos = new Vector3(0, -1.5f, 0);

    void GenerateObject()
    {
        generatedNum += 1;
        numDisplay.DisplayInt(maxGenerateNum - generatedNum);
        Instantiate(Square, this.transform.position + generateLocalPos, Quaternion.identity);
    }

    // numDisplayに正常に表示させるため、Awakeで数値を取得し、Startで反映させる
    void Awake()
    {
        maxGenerateNum = MaxGenerateNum;
        numDisplay = GetComponentInChildren<StringDisplay>();
    }
    void Start()
    {
        numDisplay.DisplayInt(maxGenerateNum);
        StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
        while (true)
        {
            if (IsTouching())
            {
                if (generatedNum < maxGenerateNum)
                {
                    GenerateObject();
                    yield return new WaitForSeconds(intervalSec);
                }
            }
            else
            {
                // 押されてないなら1F待つ
                yield return null;
            }
        }
    }
}
