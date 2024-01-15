using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int levelFinish;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        levelFinish = PlayerPrefs.GetInt("levelFinish");
    }

    void Start()
    {
        if (levelFinish != 1)
        {
            text.text = "Tiếp Tục Màn " + levelFinish;
        }
    }

    
}
