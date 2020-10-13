﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueAwake : MonoBehaviour
{
    public static DialogueAwake instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    public GameObject continueButton;
    public TextMeshProUGUI continueButtonText;

    void Start()
    {
        instance = this;
        DialogueTrigger.instance.isInteracting = true;

        StartCoroutine(StartDelayCo());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButtonText.text = "CONTINUE";
            continueButton.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (index == sentences.Length - 1)
        {
            continueButtonText.text = "CONTINUE";
        }

        if (DialogueTrigger.instance.isInteracting)
        {
            PlayerController.instance.stopMove = true;
        }
        else
        {
            PlayerController.instance.stopMove = false;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator StartDelayCo()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(Type());
    }

    public void NextSentence()
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            DialogueTrigger.instance.isInteracting = false;
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerController.instance.stopMove = false;
            DialogueTrigger.instance.isInteracting = false;
        }
    }
}
