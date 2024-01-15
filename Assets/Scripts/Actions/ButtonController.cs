using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    private GameObject player;
    private SceneSetup sceneSetup;

    void Start()
    {
        player = GameObject.Find("Player");
        sceneSetup = GetComponentInParent<SceneSetup>();
    }
    public void ButtonAnim()
    {
        GetComponent<Animation>().Play("Button");
    }

    public void buttonAnim()
    {
        GetComponent<Animation>().Play("Button");
    }

    public void JumpButton()
    {
        player.GetComponent<PlayerMoveController>().doubleJump();
        ButtonAnim();
    }

    public void DashButton()
    {
        player.GetComponent<PlayerMoveController>().dash();
        ButtonAnim();
    }

    public void AttackButton()
    {
        if (GameObject.Find("PlayerSkill1(Clone)") == null)
        {
            player.GetComponent<PlayerController>().Skill1();
        }
        ButtonAnim();
    }

    public void Skill2Button()
    {
        if (GameObject.Find("PlayerSkill2(Clone)") == null)
        {
            player.GetComponent<PlayerController>().Skill2();
        }
        ButtonAnim();
    }

  
    public void StopButton()
    {
        ButtonAnim();
        StopResume stopResume = new StopResume();
        stopResume.StopGame();
    }


    public void ResumeButton()
    {
        ButtonAnim();
        StopResume stopResume = new StopResume();
        stopResume.ResumeGame();
    }

    // replay scene
    public void ReplayButton()
    {
        ResumeButton();
        PlayerPrefs.SetInt("Heart", 3);
        StartCoroutine(CoroutineHelper.DelaySeconds(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex), 0.3f));
    }

    // reset game
    public void ResetButton()
    {
        ResumeButton();
        PlayerPrefs.SetInt("Heart", 3);
        sceneSetup.SetLevelFinish(1);
        StartCoroutine(CoroutineHelper.DelaySeconds(() => sceneSetup.LoadScene("StartScene"), 0.3f));
    }

    // exit game
    public void ExitButton()
    {
        ResumeButton();
        StartCoroutine(CoroutineHelper.DelaySeconds(() => Application.Quit(), 0.3f));
    }

    // next scene
    public void NextButton()
    {
        ButtonAnim();
        int levelFinish = sceneSetup.GetLevelFinish();
        sceneSetup.SetLevelFinish(levelFinish + 1);
        StartCoroutine(CoroutineHelper.DelaySeconds(() => sceneSetup.LoadScene("Part"+ levelFinish+1 + "Scene"), 0.3f));
    }

    public void LoadCurrentScene()
    {
        ButtonAnim();
        StartCoroutine(CoroutineHelper.DelaySeconds(() => sceneSetup.LoadCurrentScene(), 0.3f));
    }

    public void Lost()
    {
        PlayerPrefs.SetInt("Heart", 3);
        sceneSetup.SetLevelFinish(1);
        sceneSetup.LoadScene("StartScene");
    }

    public void Win()
    {
        PlayerPrefs.SetInt("Heart", 3);
        sceneSetup.SetLevelFinish(1);
        StartCoroutine(CoroutineHelper.DelaySeconds(() => sceneSetup.LoadScene("StartScene"), 0.3f));
    }

    public void NoThanAttack()
    {

    }
}
