using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(Tags.Player))
        {
            Destroy(collision.gameObject);
            Debug.Log("消滅");
        }

    }
}
