using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// キャラクターを生成する
/// </summary>
/// 実装:岩本
public class Generator : MonoBehaviour, IPointerDownHandler
{
    public GameObject generateObject;

    /// <summary>
    /// 生成するオブジェクトを事前に生成
    /// </summary>
    /// <remarks>
    /// 生成する際にInstantiateを使用するとコルーチン内で1fを超えてしまうことがあるためオブジェクトプールを実装
    /// </remarks>
    private List<GameObject> objectPool = new List<GameObject>();
    private StringDisplay numDisplay;
    private AudioSource audioSource;
    public AudioClip generateSE;    // 生成するオブジェクトによって音を変えるためpublic
    private Hover hoverComponent;

    public int MaxGenerateNum = 3;  // インスペクタから取得するため自動実装プロパティのように扱う
    private int maxGenerateNum = 1;
    private int generatedNum = 0;

    private float intervalSec = 0.5f;
    private bool isGenerating = false;
    private Vector3 generateLocalPos = new Vector3(0, -1.2f, 0);

    /// <summary>
    /// オブジェクトプールにオブジェクトを非アクティブにして追加
    /// </summary>
    void InstantiateObjects()
    {
        for (int i = 0; i < maxGenerateNum; i++)
        {
            GameObject tempObject = Instantiate(generateObject, this.transform.position + generateLocalPos, Quaternion.identity);
            tempObject.SetActive(false);
            objectPool.Add(tempObject);
        }
    }

    /// <summary>
    /// オブジェクトプールから一つづつアクティブ化
    /// アクティブ化したものはリストから削除
    /// </summary>
    void GenerateObject()
    {
        audioSource.PlayOneShot(generateSE);
        objectPool.First().SetActive(true);
        objectPool.RemoveAt(0);

        generatedNum += 1;
        int remainNum = maxGenerateNum - generatedNum;
        numDisplay.DisplayInt(remainNum);
        if (remainNum <= 0)
        {
            hoverComponent.SetDisable();
        }
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
        audioSource = GetComponent<AudioSource>();
        hoverComponent = GetComponent<Hover>();
    }

    // クリックされた際の挙動
    void IPointerDownHandler.OnPointerDown(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left && generatedNum < maxGenerateNum)
            StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
        // 2重で生成することを防ぐ
        if (isGenerating)
        {
            // 何もしない
        }
        else
        {
            isGenerating = true;
            GenerateObject();
            // 連続で生成できないように間隔を設ける
            yield return new WaitForSeconds(intervalSec);
            isGenerating = false;
        }
    }
}
