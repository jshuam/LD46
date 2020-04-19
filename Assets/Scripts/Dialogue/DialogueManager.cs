using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Queue<string> sentences;
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue( Dialogue dialogue )
    {
        sentences.Clear();

        foreach( string sentence in dialogue.sentences )
        {
            sentences.Enqueue( "<color=yellow>" + dialogue.name + "</color>: " + sentence );
        }

        StartCoroutine( FadeDialogueToFullAlpha( 0.7f ) );
        InvokeRepeating( "DisplayNextSentence", 0.0f, dialogue.speed );
    }

    public void DisplayNextSentence()
    {
        if( sentences.Count == 0 )
        {
            EndDialogue();
            return;
        }

        //Push any current existing text up here
        dialogueText.text = sentences.Dequeue();
    }

    void EndDialogue()
    {
        StartCoroutine( FadeDialogueToZeroAlpha( 0.7f ) );
        CancelInvoke( "DisplayNextSentence" );
    }

    public IEnumerator FadeDialogueToFullAlpha( float time )
    {
        canvasGroup.alpha = 0;
        while( canvasGroup.alpha < 1.0f )
        {
            canvasGroup.alpha = canvasGroup.alpha + (Time.deltaTime / time);
            yield return null;
        }
    }
 
    public IEnumerator FadeDialogueToZeroAlpha( float time )
    {
        canvasGroup.alpha = 1;
        while( canvasGroup.alpha > 0.0f )
        {
            canvasGroup.alpha = canvasGroup.alpha - (Time.deltaTime / time);
            yield return null;
        }
    }
}
