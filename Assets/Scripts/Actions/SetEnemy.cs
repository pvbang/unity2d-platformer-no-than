using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemy : MonoBehaviour
{
    public Transform[] enemy;
    private Transform player;

    public int numberSpawm = 1;

    public float timeToSpawn = 50f;
    private float timeToSpawnCountDown;
    private bool isSpawn = false;

    public bool isBoss = false;
    public GameObject boxKill;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeToSpawnCountDown = timeToSpawn;
    }

    // 2 vat the dung nhau
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isBoss)
            {
                SpawnEnemy();
                if (boxKill != null) boxKill.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else if ((timeToSpawnCountDown <= 0) | !isSpawn)
            {
                SpawnEnemy();
                timeToSpawnCountDown = timeToSpawn;
                isSpawn = true;
            }
        }
    }

    private void Update()
    {
        timeToSpawnCountDown -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < numberSpawm; i++)
        {
            int index = Random.Range(0, enemy.Length);
            Instantiate(enemy[index], new Vector3(player.position.x + 40 + (i*5), 20, 0), Quaternion.identity);
        }
    }
}
