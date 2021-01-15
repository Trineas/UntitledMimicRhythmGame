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

    public int cueSound;
    public Light playerLight;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            AudioManager.instance.PlaySFX(Random.Range(8, 10));
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
        if (!DifficultyChoice.easyMode)
        {
            ButtonFade.instance.StartFadingButtonsIn();
            NoteFade.instance.StartFadingNotesIn();
        }
    }

    public void TriggerFadeInButtonsOnly()
    {
        if (!DifficultyChoice.easyMode)
        {
            ButtonFade.instance.StartFadingButtonsIn();
        }
    }

    public void TriggerFadeOut()
    {
        if (!DifficultyChoice.easyMode)
        {
            ButtonFade.instance.StartFadingButtonsOut();
            NoteFade.instance.StartFadingNotesOut();
        }
    }

    public void PlayCue()
    {
        AudioManager.instance.PlaySFX(cueSound);
        playerLight.intensity = 25f;
    }

    public void TutorialHurt()
    {
        playerLight.intensity = 0f;
    }
}
