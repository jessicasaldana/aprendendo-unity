using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Components")]
    public float typingSpeed; //velocidade da fala

    // Variaveis de controle
    private bool isShowing; //se a janela est� visivel
    private int index; //index das senten�as
    private string[] sentences; // recebe as falas do npc

    public static DialogueControl instance;

    // Awake é chamado antes de todos os Start() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }
    
    // Chamado uma vez ao inicializar
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence() // pular pra proxima frase/fala
    {

    }

    public void Speech(string[] txt) // chamar a fala do npc
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }

}
