using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform spawn;
    public float minTimeToSpawn = 20f;
    public float maxTimeToSpawn = 50f;

    [SerializeField]
    private float timeToSpawnCountDown;

    private void Start()
    {
        timeToSpawnCountDown = 0f;
    }

    void Update()
    {
        if (timeToSpawnCountDown <= 0)
        {
            float random = Random.Range(-10f, 10f);

            Instantiate(spawn, new Vector3(transform.position.x + random, transform.position.y + random, transform.position.z), Quaternion.identity);
            timeToSpawnCountDown = Random.Range(minTimeToSpawn, maxTimeToSpawn);
        }
        timeToSpawnCountDown -= Time.deltaTime;
    }
}
