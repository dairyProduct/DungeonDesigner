using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    private void Start(){
        StartCoroutine(StartGameSequence());
    }

    IEnumerator StartGameSequence(){
        yield return new WaitForSeconds(3);
        Debug.Log("StartedDialogue");
        dialogueManager.StartNextDialogue();
    }
}
