using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues;
    
    public void TriggerDialogue()
    {
        foreach( var dialogue in dialogues )
        {
            FindObjectOfType<DialogueManager>().StartDialogue( dialogue );
        }
    }
}
