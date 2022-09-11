using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMesh textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void DisplayNum(int num){
        textMesh.text = num.ToString("0");
    }

}
