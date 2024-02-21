using System.Collections;
using UnityEngine;

/// <summary>
/// Bomberがクリックされた際に生成させる
/// 触れたRigidBodyを持つオブジェクトを削除
/// </summary>
/// 実装:岩本
public class Blast : MonoBehaviour
{
    private float blastingTime = 0.8f;

    void Start()
    {
        StartCoroutine(InactiveBlast());
    }
    IEnumerator InactiveBlast()
    {
        yield return new WaitForSeconds(blastingTime);
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
    }
}
