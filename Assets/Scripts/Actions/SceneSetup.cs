using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class SceneSetup : MonoBehaviour
{
    private int levelFinish;

    private void Awake()
    {
        ReloadLevelFinish();
    }

    public void SetLevelFinish(int level)
    {
        PlayerPrefs.SetInt("levelFinish", level);
        levelFinish = level;
    }

    public int GetLevelFinish()
    {
        ReloadLevelFinish();
        return levelFinish;
    }

    public void ReloadLevelFinish()
    {
        if (!PlayerPrefs.HasKey("levelFinish"))
        {
            PlayerPrefs.SetInt("levelFinish", 1);
            levelFinish = 1;
        }
        else
        {
            levelFinish = PlayerPrefs.GetInt("levelFinish");
        }
    }

    public void LoadScene(int level)
    {
        PlayerPrefs.SetInt("levelFinish", level);
        SceneManager.LoadScene(level);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadCurrentScene()
    {
        ReloadLevelFinish();
        LoadScene("Part" + levelFinish + "Scene");
    }

    public void LoadNextScene()
    {
        ReloadLevelFinish();
        int levelNext = levelFinish + 1;

        if (levelNext >= 5)
        {
            levelNext = 1;
        }

        levelFinish = levelNext;
        PlayerPrefs.SetInt("levelFinish", levelNext);
        LoadScene("Part" + levelNext + "Scene");
    }

}
