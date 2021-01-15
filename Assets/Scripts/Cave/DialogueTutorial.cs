using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTutorial : MonoBehaviour
{
    public static DialogueTutorial instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            AudioManager.instance.PlaySFX(Random.Range(8, 10));
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndTutorialDialogue()
    {
        textDisplay.text = "";
    }

    public void StartTutorialDialogue()
    {
        StartCoroutine(Type());
    }

    public void NextTutorialSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if (index == sentences.Length - 1)
        {
            textDisplay.text = "";
        }
        else
        {
            textDisplay.text = "";
        }
    }
}
