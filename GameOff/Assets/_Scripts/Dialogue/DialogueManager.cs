using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Serializable]
    public class DialogueUnit{ // represents 1 line of text and the facial expression the guy has while saying it
        public float textSpeed;
        public string textUnit;
        public Sprite facialExpression; // there might be like 3-5 faces
    }

    [Serializable]
    public class DialogueSegment{ // represents 1 rule which can contain multiple lines of text
        public int ruleNumber; //jus an id value to keep track of things
        public string textUnitSummery; // so we can reference what the rule is quickly
        public DialogueUnit[] textUnit; // when announcing the rule there might be a few lines of text
        
    }

    

    public TextMeshProUGUI dialogueTextUI;
    public float delayBetweenTextUnits = 2.5f;
    public SpriteRenderer faceSpriteRenderer;
    [SerializeField]
    public DialogueSegment[] nextRuleDialogueSegments;  // one for actually progressing the game
    [SerializeField]
    public DialogueSegment[] randomGoofyDialogueSegments;   // one for saying random things whatever we want idk. 
                                                    //random one will go off if the player cant get it in 30 seconds

    private int currentRuleNumber = 0; // add to rule number after previous rules are met
    private float lastSpokenDialogueTimer = 0; // if 30 secs go by unspoken have em say somin idk
    private bool isSpeaking = false;


    /// <summary>
    /// Input dialogue segment to use, it then prints it all out accordingly.
    /// </summary>
    /// <param name="currentRuleDialogue"></param>
    /// <returns></returns>
    private IEnumerator DisplayDialogueText(DialogueSegment currentRuleDialogue){
        isSpeaking = true;

        foreach(DialogueUnit dialogueUnit in currentRuleDialogue.textUnit){ //foreach textUnit
            float textSpeed = dialogueUnit.textSpeed;

            dialogueTextUI.text = "";
            faceSpriteRenderer.sprite = dialogueUnit.facialExpression;
            foreach(char character in dialogueUnit.textUnit){                                //foreach character or text
                dialogueTextUI.text += character;
                yield return new WaitForSeconds(textSpeed);
            }

            yield return new WaitForSeconds(delayBetweenTextUnits);
        }
        isSpeaking = false;
    }



    /// <summary>
    /// start next dialogue if there isn't one ongoing. if one is ongoing, add it to the queue
    /// </summary>
    /// <param name="dialogueSegment"></param>
    private void StartNextDialogue(DialogueSegment[] dialogueSegment){
        lastSpokenDialogueTimer = 0;
        if(!isSpeaking){
            StartCoroutine(DisplayDialogueText(dialogueSegment[currentRuleNumber]));
        }
    }

    private void Update(){
        lastSpokenDialogueTimer += Time.deltaTime;
        if(lastSpokenDialogueTimer >= 30){
            StartNextDialogue(randomGoofyDialogueSegments);
        }
    }
}
