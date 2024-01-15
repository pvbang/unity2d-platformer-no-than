using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartLive : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite noHeart;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    void Start()
    {
        // PlayerPrefs.SetInt("Heart", 3);
        heart1.sprite = fullHeart;
        heart2.sprite = fullHeart;
        heart3.sprite = fullHeart;
    }

    void Update()
    {
        if (PlayerPrefs.HasKey("Heart"))
        {
            int heart = PlayerPrefs.GetInt("Heart");
            if (heart == 3)
            {
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = fullHeart;
            }
            else if (heart == 2)
            {
                heart1.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart3.sprite = noHeart;
            }
            else if (heart == 1)
            {
                heart1.sprite = fullHeart;
                heart2.sprite = noHeart;
                heart3.sprite = noHeart;
            }
            else if (heart == 0)
            {
                heart1.sprite = noHeart;
                heart2.sprite = noHeart;
                heart3.sprite = noHeart;
            }
        } else
        {
            PlayerPrefs.SetInt("Heart", 3);
        }
    }

}
