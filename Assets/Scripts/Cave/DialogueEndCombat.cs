﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class DialogueEndCombat : MonoBehaviour
{
    public static DialogueMidCombat instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    public string levelToLoad;

    public GameObject continueButton;
    public TextMeshProUGUI continueButtonText;

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButtonText.text = "CONTINUE";
            continueButton.SetActive(true);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(UIManager.instance.awakeDialogueContinueButton);
        }

        if (index == sentences.Length - 1)
        {
            continueButtonText.text = "END";
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            AudioManager.instance.PlaySFX(Random.Range(8, 10));
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator SceneTransition()
    {
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(levelToLoad);
    }

    public void NextEndSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else if (index == sentences.Length - 1)
        {
            textDisplay.text = "";
            continueButton.SetActive(false);

            StartCoroutine(SceneTransition());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

    public void EndEndDialogue()
    {
        textDisplay.text = "";
        continueButton.SetActive(false);

        StartCoroutine(SceneTransition());
    }


    public void StartEndDialogue()
    {
        StartCoroutine(Type());
    }
}
