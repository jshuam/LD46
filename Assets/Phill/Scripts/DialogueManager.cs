using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue( Dialogue dialogue )
    {
        sentences.Clear();
        StartCoroutine( FadeTextToFullAlpha( 0.7f, dialogueText ) );

        foreach( string sentence in dialogue.sentences )
        {
            sentences.Enqueue( dialogue.name + ": " + sentence );
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        StartCoroutine( FadeTextToZeroAlpha( 0.7f, dialogueText ) );
    }

    public IEnumerator FadeTextToFullAlpha( float time, Text i )
    {
        i.color = new Color( i.color.r, i.color.g, i.color.b, 0 );
        while (i.color.a < 1.0f)
        {
            i.color = new Color( i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / time) );
            yield return null;
        }
    }
 
    public IEnumerator FadeTextToZeroAlpha( float time, Text i )
    {
        i.color = new Color( i.color.r, i.color.g, i.color.b, 1 );
        while (i.color.a > 0.0f)
        {
            i.color = new Color( i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / time) );
            yield return null;
        }
    }
}
