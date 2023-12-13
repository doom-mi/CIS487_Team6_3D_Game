using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    //public DialogueManager manager;
    private bool dialogueStarted = false;

    public void TriggerDialogue ()
    {
        if (!dialogueStarted)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            dialogueStarted = true;
        }
    }
}
