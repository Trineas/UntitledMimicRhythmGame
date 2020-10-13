using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (index == sentences.Length - 1)
        {
            continueButtonText.text = "CONTINUE";
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            StartCoroutine(SceneTransition());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void EndEndDialogue()
    {
        textDisplay.text = "";
    }


    public void StartEndDialogue()
    {
        StartCoroutine(Type());
    }
}
