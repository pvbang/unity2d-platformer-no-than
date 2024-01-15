using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public bool isSetScene = false;
    public int setScene = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isSetScene)
            {
                SceneSetup sceneSetup = new SceneSetup();
                sceneSetup.LoadScene(setScene);
            } else
            {
                StartCoroutine(CoroutineHelper.DelaySeconds(() => {
                    SceneSetup sceneSetup = new SceneSetup();
                    sceneSetup.LoadNextScene();
                }, 0.5f));
            }
        }
    }
}
