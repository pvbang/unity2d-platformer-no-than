using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkills : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool isDistanceAttack = false;

    // 2 vat the dung nhau
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            collision.GetComponent<PlayerController>().TakeDamage(damage);
            if (isDistanceAttack)
            {
                Destroy(this.gameObject, 0.1f);
            }
        }
    }
}
