using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedObjectDisplay : MonoBehaviour
{
    public GameObject objectToShow;
    public float delayTime = 0.5f;

    void Start()
    {
        if (objectToShow == null) objectToShow = this.gameObject;
        StartCoroutine(ShowObjectDelayed());
    }

    IEnumerator ShowObjectDelayed()
    {
        yield return new WaitForSeconds(delayTime);

        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }
    }
}
