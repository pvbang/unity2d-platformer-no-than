using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    public int numPlusHeart = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.HasKey("Heart"))
            {
                int heart = PlayerPrefs.GetInt("Heart");
                if (heart < 3)
                {
                    PlayerPrefs.SetInt("Heart", heart + numPlusHeart);
                } else
                {
                    collision.GetComponent<PlayerController>().HeadlingFullHP();
                }
            }

            Destroy(this.gameObject, 0.1f);
        }
    }
}
