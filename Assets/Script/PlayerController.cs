using System;
using UnityEngine;

public class PlayerController : Player
{
    private Rigidbody2D rigidBody2D;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        DebugLogPrint();
        if(isFreeze) return;
        BasicControl();
        DialogueStart();
    }

    private void DebugLogPrint()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(isDialogLoadable);
            Debug.Log(GameManager.isTouchedScreen);
        }
    }

    private void BasicControl()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        float xSpeed = xInput * 10;
        float ySpeed = yInput * 10;
        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        rigidBody2D.velocity = newVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        NPC npc = other.GetComponentInParent<NPC>();
        if(npc == null) return;
        if(!npc.isTalkable) return;
        if(npc.GetExpression().Length != 0) Array.Copy(npc.GetExpression(), npcExpression, 5);
        if(npc.charactorName != "") npcName = npc.charactorName;
        isDialogLoadable = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {        
        isDialogLoadable = false;
    }

}
