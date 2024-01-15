using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject[] objects;
    public bool isThisObject = false;

    public void Awake()
    {
        if (isThisObject)
        {
            objects = new GameObject[1];
            objects[0] = gameObject;
        }
    }

    public void SetActiveObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }

    public void SetDeactiveObjects()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
}
