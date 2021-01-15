using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueCombat : MonoBehaviour
{
    public static DialogueCombat instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    public GameObject continueButton;
    public TextMeshProUGUI continueButtonText;

    void Start()
    {
        instance = this;
        StartCoroutine(StartDelayCo());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButtonText.text = "CONTINUE";
            continueButton.SetActive(true);

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(UIManager.instance.dialogueContinueButton);
        }

        if (index == sentences.Length - 1)
        {
            continueButtonText.text = "FIGHT!";
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            AudioManager.instance.PlaySFX(Random.Range(8, 10));
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

            GameManager.instance.startPlaying = true;
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        StartCoroutine(Type());
    }
}
