using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsKillBoss : MonoBehaviour
{
    public string bossName;
    private GameObject boss;

    void Start()
    {
        boss = GameObject.Find(bossName);
    }

    void Update()
    {
        if (boss == null)
        {
            Destroy(gameObject);
        }
    }
}
