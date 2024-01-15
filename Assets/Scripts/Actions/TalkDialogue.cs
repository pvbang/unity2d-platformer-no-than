using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed = 0.03f;

    private int index;

    public GameObject talkStartScene;
    private Animator animator;

    private void Awake()
    {
        if (textDisplay == null)
            textDisplay = GetComponentInChildren<TextMeshProUGUI>();

        talkStartScene = gameObject.transform.parent.gameObject;
        animator = talkStartScene.GetComponent<Animator>();
    }

    void Start()
    {
        animator.SetTrigger("talk");
        textDisplay.text = string.Empty;
        StartCoroutine(Type());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textDisplay.text == sentences[index])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                textDisplay.text = sentences[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(Type());
        }
        else
        {
            animator.SetTrigger("endtalk");
            StartCoroutine(CoroutineHelper.DelaySeconds(() => talkStartScene.SetActive(false), 1f));
        }
    }
}
