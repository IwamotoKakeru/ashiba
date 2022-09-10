using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject reticle;
    Collider2D cursorCollider;
    private Vector3 mousePosition, target;

    void Start()
    {
        //カーソルのコライダーを取得
        cursorCollider = this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        target = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = target;

        //クリックされたときのみカーソルの当たり判定をOnにする
        if(Input.GetMouseButton(0)){
            cursorCollider.enabled = true;
        }else{
            cursorCollider.enabled = false;
        }
    }
}
