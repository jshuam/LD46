﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogue;
    public Queue<string> sentences;
    
    private CanvasGroup _canvasGroup;
    private Text _dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        _dialogueText = dialogue.GetComponent<Text>();
        _canvasGroup = dialogue.GetComponent<CanvasGroup>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue("<color=yellow>" + dialogue.name + "</color>: " + sentence);
        }

        if( _canvasGroup.alpha == 0 )
        {
            StartCoroutine(FadeDialogueToFullAlpha(0.7f));
            InvokeRepeating("DisplayNextSentence", 0.0f, dialogue.speed);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        _dialogueText.text = sentences.Dequeue();
    }

    void EndDialogue()
    {
        StartCoroutine(FadeDialogueToZeroAlpha(0.7f));
        CancelInvoke("DisplayNextSentence");
    }

    public IEnumerator FadeDialogueToFullAlpha(float time)
    {
        _canvasGroup.alpha = 0;
        while (_canvasGroup.alpha < 1.0f)
        {
            _canvasGroup.alpha = _canvasGroup.alpha + (Time.deltaTime / time);
            yield return null;
        }
    }

    public IEnumerator FadeDialogueToZeroAlpha(float time)
    {
        _canvasGroup.alpha = 1;
        while (_canvasGroup.alpha > 0.0f)
        {
            _canvasGroup.alpha = _canvasGroup.alpha - (Time.deltaTime / time);
            yield return null;
        }
    }
}
