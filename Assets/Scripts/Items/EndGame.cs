using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject win;
    public GameObject LassBoss;

    // Start is called before the first frame update
    void Start()
    {
        LassBoss = GameObject.Find("Marco (6)");
    }

    // Update is called once per frame
    void Update()
    {
        if (LassBoss == null)
        {
            win.SetActive(true);
        }
    }
}
