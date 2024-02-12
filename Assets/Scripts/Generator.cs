using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using System.Linq;

public class Generator : TouchChecker
{
    // 検知するタグをカーソルに変更
    public override string ObjectTag => Tags.Cursor;

    public GameObject gameObject;
    private List<GameObject> objectPool = new List<GameObject>();
    private StringDisplay numDisplay;

    // インスペクタから取得するため自動実装プロパティのように扱う
    public int MaxGenerateNum = 3;
    private int maxGenerateNum = 1;
    private int generatedNum = 0;

    private float intervalSec = 1.0f;
    private Vector3 generateLocalPos = new Vector3(0, -1.5f, 0);

    void InstantiateObjects()
    {
        for (int i = 0; i < maxGenerateNum; i++)
        {
            GameObject tempObject = Instantiate(gameObject, this.transform.position + generateLocalPos, Quaternion.identity);
            tempObject.SetActive(false);
            objectPool.Add(tempObject);
        }
    }

    void GenerateObject()
    {
        objectPool.First().SetActive(true);
        objectPool.RemoveAt(0);
        generatedNum += 1;
        numDisplay.DisplayInt(maxGenerateNum - generatedNum);
    }

    // numDisplayに正常に表示させるため、Awakeで数値を取得し、Startで反映させる
    void Awake()
    {
        maxGenerateNum = MaxGenerateNum;
        InstantiateObjects();
        numDisplay = GetComponentInChildren<StringDisplay>();
    }
    void Start()
    {
        numDisplay.DisplayInt(maxGenerateNum);
        StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
        while (generatedNum < maxGenerateNum)
        {
            Debug.Log(IsTouching());
            if (IsTouching())
            {
                GenerateObject();
                yield return new WaitForSeconds(intervalSec);
            }
            // 1F待つ
            yield return null;
        }
        Debug.Log("End coroutine");
    }
}
