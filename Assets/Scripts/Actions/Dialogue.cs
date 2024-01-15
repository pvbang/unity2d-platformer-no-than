using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed = 0.5f;

    private int index;

    private void Awake()
    {
        if (textDisplay == null)
            textDisplay = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
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
            } else
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
        } else
        {
            GameObject npc = GameObject.FindGameObjectWithTag("NPC");
            npc.SetActive(false);

            GameObject parent = transform.parent.gameObject;

            parent.GetComponent<Animator>().SetTrigger("endtalk");
            StartCoroutine(CoroutineHelper.DelaySeconds(() => parent.SetActive(false), 1f));
        }
    }
}
