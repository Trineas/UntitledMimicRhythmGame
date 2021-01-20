using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueCredits : MonoBehaviour
{
    public static DialogueCredits instance;

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;

    void Start()
    {
        instance = this;
        StartCoroutine(StartDelayCo());
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
           Credits.instance.PlayCredits();
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

    IEnumerator StartDelayCo()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(Type());
    }
}
