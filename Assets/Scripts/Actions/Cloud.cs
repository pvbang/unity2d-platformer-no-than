using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x - moveSpeed, y, z), step);
    }
}
