using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoss : MonoBehaviour
{
    public GameObject marco;

    void Start()
    {
        marco = GameObject.Find("Marco");
    }

    void Update()
    {
        marco = GameObject.Find("Marco");
        if (marco == null)
        {
            Destroy(gameObject);
        }
    }
}
