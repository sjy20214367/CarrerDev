using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DialogueSystem.DialogueUI dialogueUI;

    [Header("Charactor Settings")]
    public string charactorName;    
    public Sprite[] expression;

    protected string npcName;
    protected Sprite [] npcExpression = new Sprite[5];
    protected bool isDialogLoadable;
    protected bool isFreeze;

    protected void DialogueStart()
    {
        if(!Input.GetKeyDown(KeyCode.G) || !isDialogLoadable) return;
        Freeze();
        dialogueUI.ShowDialogueUI(GameManager.sceneNumberToLoad, expression, npcExpression, charactorName, npcName);
    }

    protected void DialogueEnd()
    {
        dialogueUI.CloseDialogueUI();
        Unfreeze();
    }

    protected void Unfreeze()
    {
        isFreeze = false;
    }

    protected void Freeze()
    {
        isFreeze = true;
    }
}
