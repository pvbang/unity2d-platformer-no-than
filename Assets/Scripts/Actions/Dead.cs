using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    public GameObject lost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.HasKey("Heart"))
            {
                int heart = PlayerPrefs.GetInt("Heart");
                if (heart == 3)
                {
                    heart = 2;
                }
                else if (heart == 2)
                {
                    heart = 1;
                }
                else if (heart == 1)
                {
                    heart = 0;
                }
                else if (heart == 0)
                {
                    lost.SetActive(true);
                }
                PlayerPrefs.SetInt("Heart", heart);
            }
            else
            {
                PlayerPrefs.SetInt("Heart", 2);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
