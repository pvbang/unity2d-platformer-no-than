using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScripts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
        }

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
        }

    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Objects"))
    //    {
    //        Debug.Log("Object");
    //    }
    //}

}
