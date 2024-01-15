using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage;
    public bool isTrap = true;
    public bool isDestroy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isTrap)
            {
                collision.GetComponent<PlayerController>().TakeDamage(damage);
            }

            if (isDestroy)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
