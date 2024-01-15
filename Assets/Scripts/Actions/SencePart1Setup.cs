using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SencePart1Setup : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {

    }


}
