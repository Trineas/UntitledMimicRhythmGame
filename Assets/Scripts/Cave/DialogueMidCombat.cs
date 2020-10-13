using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueMidCombat : MonoBehaviour
{
    public static DialogueMidCombat instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {
        textDisplay.text = "";
    }


    public void StartDialogue()
    {
        StartCoroutine(Type());
    }
}
