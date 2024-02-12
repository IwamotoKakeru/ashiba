﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;
using System.Linq;
using UnityEngine.EventSystems;

public class Generator : MonoBehaviour, IPointerDownHandler
{
    public GameObject generateObject;
    private List<GameObject> objectPool = new List<GameObject>();
    private StringDisplay numDisplay;

    // インスペクタから取得するため自動実装プロパティのように扱う
    public int MaxGenerateNum = 3;
    private int maxGenerateNum = 1;
    private int generatedNum = 0;

    private float intervalSec = 1.0f;
    private bool isGenerating = false;
    private Vector3 generateLocalPos = new Vector3(0, -1.5f, 0);

    void InstantiateObjects()
    {
        for (int i = 0; i < maxGenerateNum; i++)
        {
            GameObject tempObject = Instantiate(generateObject, this.transform.position + generateLocalPos, Quaternion.identity);
            tempObject.SetActive(false);
            objectPool.Add(tempObject);
        }
    }

    void GenerateObject()
    {
        Debug.Log("Clicked");
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
    }

    // クリックされた際の挙動
    void IPointerDownHandler.OnPointerDown(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left && generatedNum < maxGenerateNum)
            StartCoroutine(GenerateCoroutine());
    }

    private IEnumerator GenerateCoroutine()
    {
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
