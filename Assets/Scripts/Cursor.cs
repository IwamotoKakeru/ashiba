using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 mousePosition, target;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        target = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = target;

    }
}
