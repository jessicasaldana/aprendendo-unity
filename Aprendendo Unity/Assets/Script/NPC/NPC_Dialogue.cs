using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange; // Tamanho do colisor
    public LayerMask playerLayer; // Layer do player

    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();

    void Start()
    {
        GetNPCInfo();
    }

    // É chamado a cada frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray);
        }
    }

    // É usado pela fisica
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
