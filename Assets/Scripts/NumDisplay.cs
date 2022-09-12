using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMesh textMesh;
    private int num;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    public void DisplayNum(int numGetter){
        num = numGetter;
    }

    void Update(){
        textMesh.text = num.ToString("0");
    }

}
