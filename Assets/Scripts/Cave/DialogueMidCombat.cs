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

    public void TriggerFadeIn()
    {
        if (!GameManager.instance.easyMode)
        {
            ButtonFade.instance.StartFadingButtonsIn();
            NoteFade.instance.StartFadingNotesIn();
        }
    }

    public void TriggerFadeOut()
    {
        if (!GameManager.instance.easyMode)
        {
            ButtonFade.instance.StartFadingButtonsOut();
            NoteFade.instance.StartFadingNotesOut();
        }
    }
}
