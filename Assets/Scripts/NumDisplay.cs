using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMesh textMesh;
    Goal goal;
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        goal = transform.parent.gameObject.GetComponent<Goal>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = goal.returnGoalNum().ToString("0");
    }
}
